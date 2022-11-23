// using System.Threading.Tasks;
// using AspNetTelegramBot.Src.BotApplication.Code;
// using MarathonBot.SantaBot.Data.States;
// using SantaBot.Data.States.SetPhoto;
// using Telegram.BotApplication.Types;
// using Telegram.BotApplication.Types.Enums;
//
// namespace SantaBot.Data.States.SetContact
// {
//     public class SetContactBotStateProcessor : BaseSantaStateProcessor
//     {
//         public SetContactBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
//         {
//             RequiredMessageType = MessageType.Text;
//         }
//         
//         protected override async Task<Hop> TextMessageProcess(Message mes)
//         {
//
//             var ui = await DbStore.Repos.UserInfo.GetByUserId(CurrentUser.Id);
//             
//             if (mes.Text != SetContactVars.BtnSetCurrent)
//             {
//                 ui.Contact = mes.Text;
//                 await DbStore.Repos.UserInfo.UpdateAsync(ui);
//             }
//             
//             var hop =  new Hop(new HopInfo("SetPhoto", SetPhotoVars.Introduction, HopType.CurrentLevelHop), 
//                 CurrentState, 
//                 StateStorage.Get("SetPhoto"));
//             if (ui.Photo != null)
//             {
//                 hop.PriorityKeyboard = SetPhotoVars.GetDefaultValueKeyboard().Value;
//             }
//
//             return hop;
//         }
//     }
// }