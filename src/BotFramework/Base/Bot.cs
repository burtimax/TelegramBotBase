using Telegram.Bot;

namespace BotFramework.Base
{
    /// <summary>
    /// базовый класс бота 
    /// </summary>
    public abstract class Bot
    {
        public TelegramBotClient ApiClient { get; set; }
        
        public Bot(TelegramBotClient apiClient)
        {
            ApiClient = apiClient;
        }
    }
}