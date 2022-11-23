using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotApplication.Bot.Code;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;

namespace BotApplication.BotStore.Data.Commands
{
    public class BotSendAllCommand : Bot.Code.BotCommand
    {
        public BotSendAllCommand(string str) : base(str)
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
            
            List<long> allUsersChatIdList = await data.dbBot.User.Select(u=>u.Id).ToListAsync();

            foreach (var chatId in allUsersChatIdList)
            {
                await data.bot.SendTextMessageAsync(chatId, messageToAll);
            }
            
            return null;
        }
    }
}