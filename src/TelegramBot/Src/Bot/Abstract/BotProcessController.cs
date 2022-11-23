﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using BotApplication.Bot.Code;
using BotApplication.Bot.Db.DbBot;
using BotApplication.Bot.ExtensionsMethods;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Chat = Telegram.Bot.Types.Chat;
using User = Telegram.Bot.Types.User;

namespace BotApplication.Bot.Abstract
{
    public abstract class BotProcessController
    {
        public Code.Bot bot;
        private BotControllerAdditionalMethods additionalMethods;

        private BotUpdateProcessor updateProcessor;

        protected BotProcessController(Code.Bot bot)
        {
            this.bot = bot;
            this.additionalMethods = new BotControllerAdditionalMethods();
        }

        protected BotProcessController(Code.Bot bot, BotControllerAdditionalMethods additionalMethods):this(bot)
        {
            this.additionalMethods = additionalMethods;
        }

        

        public virtual async Task ProcessUpdate(object sender, Update update)
        {
            try
            {
                //Create BotContext concrete object
                BotContext dbBotContext = bot.GetNewBotContext();
                this.additionalMethods.Db = dbBotContext;

                //Get objects from Update
                User telegramUser = update.GetUser();
                Chat telegramChat = update.GetChat();

                await AddUserIfNeed(telegramUser);
                await AddChatIfNeed(telegramChat);
                await SaveMessageIfNeed(update);
                
                //Это мой костыль (нужен пока здесь) //ToDo потом убрать
                #region Костыль
                var user = await dbBotContext.User.FirstOrDefaultAsync(u => u.Id == telegramUser.Id);
                if (user != null)
                {
                    user.Username = telegramUser.Username;
                    dbBotContext.User.Update(user);
                    await dbBotContext.SaveChangesAsync();
                }
                #endregion

                //Get Chat model from DataBase to process Update
                Db.DbBot.Chat chatModel = await additionalMethods.GetChat(telegramChat.Id);
                var curState = bot.StateStorage.Get(chatModel.GetCurrentStateName());
                string curStateName = curState.ClassName;
                //---Process Update---
                //Find BotStateProcessor Class
                string processorClassName = $"{bot.BotNamespaceStatePrefix}{curStateName}.{curStateName}BotStateProcessor";
                Type processorType = Assembly.GetExecutingAssembly().GetType(processorClassName, true, true);

                //Collect Data for Processing
                UpdateBotModel data = new UpdateBotModel()
                {
                    bot = this.bot.client,
                    dbBot = dbBotContext,
                    stateStorage = bot.StateStorage,
                    commandStorage = bot.CommandStorage,
                    state = curState,
                    update = update,
                    chat = await additionalMethods.GetChat(telegramChat.Id),
                    user = await additionalMethods.GetUser(telegramUser.Id)
                };

                //Create Instance of Found BotStateProcessorClass
                var processor = Activator.CreateInstance(processorType, data);
                MethodInfo methodProcessor = processorType.GetMethod("ProcessUpdate");

                if (methodProcessor == null) throw new Exception($"Method [ProcessUpdate] don't exists in processor type {processorType.Name}!");

                //Invoke Process method and Get Hop Data
                Hop hop = await (methodProcessor.Invoke(processor, null) as Task<Hop>);

                if (hop == null) throw new Exception("Hop can't be NULL");

                //Get hop, get State, Update CurrentState in Db

                //Change Chat CurrentState by hop type
                chatModel.SetState(hop.PriorityNextStateName, hop.PriorityHopType);

                Db.DbBot.Chat c = new Db.DbBot.Chat()
                {
                    Id = chatModel.Id,
                    State= chatModel.State,
                    StateData = hop.PriorityData != null ? hop.PriorityData : chatModel.StateData,
                };
                await additionalMethods.SetChatData(c);

                if (hop.BlockSendAnswer == false)
                {
                    OutboxMessage outboxMessage = new OutboxMessage(hop.PriorityIntroduction);
                    if (hop.PriorityKeyboard != null)
                    {
                        outboxMessage.ReplyMarkup = hop.PriorityKeyboard;
                    }

                    outboxMessage.ParseMode = ParseMode.Html;
                    await bot.client.SendOutboxMessageAsync(chatModel.Id, outboxMessage);
                    //outboxMessage.SendOutboxMessage(BotApplication.client, chatModel.Id);
                }
                
            }
            catch (Exception exception)
            {
                await bot.client.SendTextMessageAsync(new ChatId(AppConstants.SupportUserId), $"<b>ERROR</b>\n\n" +
                                                                       $"<b>MESSAGE</b>\n{exception.Message}\n\n" +
                                                                       $"<b>STACK TRACE</b>{exception.StackTrace}\n\n",
                    ParseMode.Html);
                //in case of exception not save changes
                this.additionalMethods.Db = null;
            }
            finally
            {
                //if wasn't exception save changes
                if(this.additionalMethods.Db != null)
                {
                    await this.additionalMethods.Db.SaveChangesAsync();
                    this.additionalMethods.Db = null;
                }
            }

        }


        private async Task AddUserIfNeed(User user)
        {
            if (user == null) throw new Exception("User is NULL");

            if (await additionalMethods.IsUserInBot(user.Id) == false)
            {
                await additionalMethods.AddUserToBot(user);
            }
        }

        private async Task AddChatIfNeed(Chat chat)
        {
            if (chat == null) throw new Exception("Chat is NULL");

            if (await additionalMethods.IsChatInBot(chat.Id) == false)
            {
                await additionalMethods.AddChatToBot(chat);
            }
        }

        private async Task SaveMessageIfNeed(Update update)
        {
            if (update == null) return;

            if (update.Type == UpdateType.Message)
            {
                await additionalMethods.SaveMessage(update.Message);
            }
        }
    }
}
