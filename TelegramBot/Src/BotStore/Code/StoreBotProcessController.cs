using System.Threading.Tasks;
using BotApplication.Bot.Abstract;
using BotApplication.Bot.Code;
using Telegram.Bot.Types;

namespace BotApplication.BotStore.Code
{
    public class StoreBotProcessController : BotProcessController
    {
        public StoreBotProcessController(Bot.Code.Bot bot) : base(bot)
        {
        }

        public StoreBotProcessController(Bot.Code.Bot bot, BotControllerAdditionalMethods additionalMethods) : base(bot, additionalMethods)
        {
        }

        public override Task ProcessUpdate(object sender, Update update)
        {
            //My Work
            return base.ProcessUpdate(sender, update);
        }
    }
}