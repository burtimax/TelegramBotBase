using System;
using System.Threading.Tasks;
using BotApplication.Bot.Code;
using BotApplication.BotStore.Data.States.Basket;
using BotApplication.BotStore.Db.Entities;
using BotApplication.BotStore.Helpers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Message = Telegram.Bot.Types.Message;

namespace BotApplication.BotStore.Data.States.Main
{
    public class MainBotStateProcessor : BaseSantaStateProcessor
    {
        public MainBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
        {
            RequiredMessageType = MessageType.Text;
        }

        
        protected override async Task<Hop> TextMessageProcess(Message mes)
        {
            string text = mes.Text;
            if (mes.Text == MainVars.ProductsBtn)
            {
                // Показать первый товар
                Product product = (await DbStore.Repos.ProductRepository.GetProductByIndex(0));
                await SendProductCard(product, 0, false);
                return defaultHop.BlockAnswer();
                
            }
            
            if (mes.Text == MainVars.BasketBtn)
            {
                // Перейти в состояние корзины
                Hop hop = new Hop(
                    new HopInfo("Basket", await BasketVars.GetBasketByUser(DbStore, CurrentUser.Id),
                        HopType.CurrentLevelHop, dynamicKeyboard: BasketVars.BasketKeyboard().Value),
                    CurrentState,
                    StateStorage.Get("Basket"));
                
                return hop;
                
            }

            var keyboard = MainVars.MainKeyboard; //await MainVars.InlineChoseProducer(DbStore);
            await Bot.SendTextMessageAsync(Chat.Id, MainVars.Introduction, replyMarkup: keyboard.Value);
            return defaultHop.BlockAnswer();
        }

        protected override async Task<Hop> ProcessCallback(CallbackQuery callback)
        {
            string str = callback.Data;

            if (str.StartsWith(MainVars.ShowAnotherProductCallbackPrefix))
            {
                string[] values = str.Split(':');
                int productIndex = Convert.ToInt32(values[1]);
                Product product = (await DbStore.Repos.ProductRepository.GetProductByIndex(productIndex));
                await Bot.AnswerCallbackQueryAsync(callback.Id);
                await SendProductCard(product, productIndex, true);
                return defaultHop.BlockAnswer();
            }
            
            if (str.StartsWith(MainVars.AddProductToBasketCallbackPrefix))
            {
                string[] values = str.Split(':');
                int productIndex = Convert.ToInt32(values[1]);
                Product product = (await DbStore.Repos.ProductRepository.GetProductByIndex(productIndex));
                // Добавить товар в корзину
                await DbStore.Repos.BasketRepository.AddProductToBasket(CurrentUser.Id, product);
                await DbStore.SaveChangesAsync();
                await Bot.AnswerCallbackQueryAsync(callback.Id);
                await SendProductCard(product, productIndex, true);
                defaultHop.BlockSendAnswer = true;
                return defaultHop.BlockAnswer();
            }
            
            if (str.StartsWith(MainVars.RemoveProductFromBasketCallbackPrefix))
            {
                string[] values = str.Split(':');
                int productIndex = Convert.ToInt32(values[1]);
                Product product = (await DbStore.Repos.ProductRepository.GetProductByIndex(productIndex));
                // Убрать из корзины
                await DbStore.Repos.BasketRepository.RemoveProductFromBasket(CurrentUser.Id, product.Id);
                await DbStore.SaveChangesAsync();
                await Bot.AnswerCallbackQueryAsync(callback.Id);
                await SendProductCard(product, productIndex, true);
                defaultHop.BlockSendAnswer = true;
                return defaultHop.BlockAnswer();
            }

            return await base.ProcessCallback(callback);
        }


        public async Task SendProductCard(Product product, int productIndex, bool edit = false)
        {
            string description = MainVars.GetProductDescription(product);
            IReplyMarkup inline = (await MainVars.ProductInlineMarkup(CurrentUser.Id, DbStore, productIndex)).Value;

            FileData fd = new FileData();
            fd.Data = System.IO.File.ReadAllBytes(PhotoHelper.GetPhotoFilePath(product.ImagePath));
            fd.Info = new File();

            MessagePhoto messagePhoto = new MessagePhoto(fd, description);

            OutboxMessage mes = new OutboxMessage(messagePhoto);
            mes.ReplyMarkup = inline;

            if (edit == false)
            {
                await Bot.SendOutboxMessageAsync(Chat.Id, mes);
            }
            else
            {
                int mesId = Update.CallbackQuery.Message.MessageId;
                await Bot.DeleteMessageAsync(Chat.Id, mesId);
                await Bot.SendOutboxMessageAsync(Chat.Id, mes);
            }
            
        }
    }
}