using BotApplication.Bot.Db.DbBot;
using Telegram.Bot;

namespace BotApplication.Bot.Code
{
    public abstract class Bot
    {
        public Bot(string botBotNamespaceStatePrefix, TelegramBotClient client, BotStateStorage states, BotCommandStorage commands)
        {
            this.client = client;
            this.StateStorage = states;
            this.CommandStorage = commands;
            this.BotNamespaceStatePrefix = botBotNamespaceStatePrefix;
        }

        /// <summary>
        /// BotNamespaceStatePrefix should be contains in states namespace
        /// </summary>
        public string BotNamespaceStatePrefix { get; set; }
        public TelegramBotClient client { get; set; }
        public BotStateStorage StateStorage { get; set; }
        public BotCommandStorage CommandStorage { get; set; }
        
        public BotContext BotDbContext { get; set; }

        public BotContext GetNewBotContext()
        {
            return BotDbContext;
        }


    }
}
