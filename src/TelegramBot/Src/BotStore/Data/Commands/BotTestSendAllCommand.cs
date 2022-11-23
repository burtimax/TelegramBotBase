using System.Threading.Tasks;
using BotApplication.Bot.Code;
using Telegram.Bot;

namespace BotApplication.BotStore.Data.Commands
{
    public class BotTestSendAllCommand : Bot.Code.BotCommand
    {
        public BotTestSendAllCommand(string str) : base(str)
        {
            
        }

        public override async Task<Hop> ExecCommand(UpdateBotModel data)
        {
            if (data.user.Id.ToString() != AppConstants.SupportUserId) return null;

            string text = data.update.Message.Text;

            string messageToAll = text.Substring(Instruction.Length).Trim(' ');

            if (string.IsNullOrWhiteSpace(messageToAll) == true)
            {
                await data.bot.SendTextMessageAsync(AppConstants.SupportUserId, "Сообщение пустое");
                return null;
            }
            
            await data.bot.SendTextMessageAsync(AppConstants.SupportUserId, messageToAll);
            
            return null;
        }
    }
}