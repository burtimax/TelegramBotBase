﻿// using System.Threading.Tasks;
// using AspNetTelegramBot.Src.BotApplication.Code;
// using MarathonBot.SantaBot.Data.States;
// using MarathonBot.SantaBot.Helpers;
// using SantaBot.Data.States.SetDescription;
// using Telegram.BotApplication.Types;
// using Telegram.BotApplication.Types.Enums;
// using BotFramework.Src.Enums;
// using BotFramework.Src.Tools;
//
// namespace SantaBot.Data.States.SetPhoto
// {
//     public class SetPhotoBotStateProcessor : BaseSantaStateProcessor
//     {
//         public SetPhotoBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
//         {
//             RequiredMessageType = MessageType.Photo;
//         }
//
//         protected override async Task<Hop> TextMessageProcess(Message mes)
//         {
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             
//             if (mes.Text == SetPhotoVars.BtnSetCurrent)
//             {
//                 var hop = successHop;
//                 if (ui.Description != null)
//                 {
//                     hop.PriorityKeyboard = SetDescriptionVars.GetDefaultValueKeyboard().Value;
//                 }
//
//                 return hop;
//             }
//
//             return defaultHop;
//         }
//
//         protected override async Task<Hop> PhotoMessageProcess(Message mes)
//         {
//
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             
//             InboxMessage messageData = new InboxMessage(BotApplication, mes);
//             var photo = await messageData.GetMessagePhotoAsync(PhotoQuality.High);
//
//             var photoPath = PhotoHelper.GetPhotoFilePathForUser(CurrentUser.Id.ToString());
//             photo.File.SaveFile(photoPath);
//             
//             ui.Photo = PhotoHelper.GetPhotoFileNameForUser(CurrentUser.Id.ToString());
//             await DbStore.Repos.UserInfo.UpdateAsync(ui);
//             
//
//             var hop = successHop;
//             if (ui.Description != null)
//             {
//                 hop.PriorityKeyboard = SetDescriptionVars.GetDefaultValueKeyboard().Value;
//             }
//
//             return hop;
//         }
//     }
// }