using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotTools.Interfaces;

namespace TelegramBotTools.Implementation
{
    /// <inheritdoc cref="IUpdateHandler"/>
    public class UpdateHandler : IUpdateHandler
    {
        public TelegramBotClient BotClient { get; set; }

        public UpdateHandler(TelegramBotClient bot)
        {
            if (bot == null) throw new Exception("BotApplication parameter can't be NULL!");

            this.BotClient = bot;
        }
        
        /// <inheritdoc/>
        public async Task HandleUpdateAsync()
        {
        }
    }
}
