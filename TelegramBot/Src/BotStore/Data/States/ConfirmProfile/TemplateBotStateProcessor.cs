﻿// using System.Threading.Tasks;
// using AspNetTelegramBot.Src.BotApplication.Code;
// using MarathonBot.SantaBot.Data.States;
// using SantaBot.Data.States._TEMPLATE_;
// using SantaBot.Data.States.Start;
// using Telegram.BotApplication.Types;
// using Telegram.BotApplication.Types.Enums;
//
// namespace SantaBot.Data.States.ConfirmProfile
// {
//     public class ConfirmProfileBotStateProcessor : BaseSantaStateProcessor
//     {
//         public ConfirmProfileBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
//         {
//             RequiredMessageType = MessageType.Text;
//         }
//         
//
//         protected override async Task<Hop> TextMessageProcess(Message mes)
//         {
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             var ans = mes.Text;
//
//             if (mes.Text == ConfirmProfileVars.BtnNorm)
//             {
//                 return successHop;
//             }
//
//             if (mes.Text == ConfirmProfileVars.BtnEdit)
//             {
//                 var hop =  new Hop(new HopInfo("SetName", SetNameVars.Introduction, HopType.CurrentLevelHop), 
//                     CurrentState, 
//                     StateStorage.Get("SetName"));
//                 if (ui.BotNamespaceStatePrefix != default)
//                 {
//                     hop.PriorityKeyboard = SetNameVars.GetDefaultValueKeyboard(ui.BotNamespaceStatePrefix).Value;
//                 }
//
//                 return hop;
//             }
//
//             return defaultHop;
//         }
//     }
// }