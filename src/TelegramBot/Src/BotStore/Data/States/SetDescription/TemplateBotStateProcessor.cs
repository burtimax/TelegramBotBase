// using System.Threading.Tasks;
// using AspNetTelegramBot.Src.BotApplication.Code;
// using BotApplication.DbModel.Entities;
// using MarathonBot.SantaBot.Data.States;
// using MarathonBot.SantaBot.Service;
// using Telegram.BotApplication.Types;
// using Telegram.BotApplication.Types.Enums;
//
// namespace SantaBot.Data.States.SetDescription
// {
//     public class SetDescriptionBotStateProcessor : BaseSantaStateProcessor
//     {
//         public SetDescriptionBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
//         {
//             RequiredMessageType = MessageType.Text;
//         }
//         
//
//         protected override async Task<Hop> TextMessageProcess(Message mes)
//         {
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             
//             if (mes.Text == SetDescriptionVars.BtnSetCurrent)
//             {
//                 await SendProfileForConfirmation(ui);
//                 return successHop;
//             }
//             
//             ui.Description = mes.Text;
//             await DbStore.Repos.UserInfo.UpdateAsync(ui);
//
//             await SendProfileForConfirmation(ui);
//             return successHop;
//         }
//
//
//         private async Task SendProfileForConfirmation(Product myProfile)
//         {
//             ProfileService profileService = new ProfileService();
//             await profileService.SendProfile(BotApplication, Chat.Id, myProfile);
//         }
//     }
// }