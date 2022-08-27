using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotTools.Controller
{
    public class UpdateProcessController : IUpdateProcessController
    {
        public TelegramBotClient bot { get; set; }

        public UpdateProcessController(TelegramBotClient _bot)
        {
            if (_bot == null) throw new Exception("BotApplication parameter can't be NULL!");

            this.bot = _bot;
        }

        

        public async Task ProcessUpdateAsync()
        {
            
        }
    }
}
