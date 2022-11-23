using System.Threading.Tasks;
using Telegram.Bot;

namespace BotApplication.Helpers
{
    public class BotSingleton
    {
        private static global::BotApplication.BotStore.Code.BotStore _botStore;

        public static async Task<global::BotApplication.BotStore.Code.BotStore> GetInstanceAsync()
        {
            if (_botStore == null)
            {
                var telegramClient = new TelegramBotClient(AppConstants.BotToken);
                await telegramClient.SetWebhookAsync(AppConstants.BotWebhook);
                _botStore = new global::BotApplication.BotStore.Code.BotStore(telegramClient);
                
            }
           
            return _botStore;
        }
        
    }
}