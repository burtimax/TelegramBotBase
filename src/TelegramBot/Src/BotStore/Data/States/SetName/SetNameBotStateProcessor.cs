﻿// using System.Threading.Tasks;
// using AspNetTelegramBot.Src.BotApplication.Code;
// using MarathonBot.SantaBot.Data.States;
// using SantaBot.Data.States._TEMPLATE_;
// using Telegram.BotApplication.Types;
// using Telegram.BotApplication.Types.Enums;
// using User = AspNetTelegramBot.Src.DbModel.DbBot.User;
//
// namespace SantaBot.Data.States.SetName
// {
//     public class SetNameBotStateProcessor : BaseSantaStateProcessor
//     {
//         public SetNameBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
//         {
//             RequiredMessageType = MessageType.Text;
//         }
//
//         protected override async Task<Hop> TextMessageProcess(Message mes)
//         {
//
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             ui.BotNamespaceStatePrefix = mes.Text;
//             await DbStore.Repos.UserInfo.UpdateAsync(ui);
//
//             var hop =  new Hop(new HopInfo("SetAge", SetAgeVars.Introduction, HopType.CurrentLevelHop), 
//                 CurrentState, 
//                 StateStorage.Get("SetAge"));
//             if (ui.Age != default)
//             {
//                 hop.PriorityKeyboard = SetAgeVars.GetDefaultValueKeyboard(ui.Age).Value;
//             }
//
//             return hop;
//         }
//         
//         
//         
//     }
// }