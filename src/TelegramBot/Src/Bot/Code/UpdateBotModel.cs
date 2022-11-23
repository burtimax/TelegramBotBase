using BotApplication.Bot.Db.DbBot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Chat = BotApplication.Bot.Db.DbBot.Chat;
using User = BotApplication.Bot.Db.DbBot.User;


namespace BotApplication.Bot.Code
{
    public class UpdateBotModel
    {
        public User user { get; set; }
        public Chat chat { get; set; }
        public BotState state { get; set; }
        public BotContext dbBot { get; set; }
        public TelegramBotClient bot { get; set; }
        public Update update { get; set; }
        public BotStateStorage stateStorage { get; set; }
        public BotCommandStorage commandStorage { get; set; }
    }
}
