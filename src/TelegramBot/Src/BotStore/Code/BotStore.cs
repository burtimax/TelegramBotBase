using BotApplication.BotStore.Data;
using Telegram.Bot;

namespace BotApplication.BotStore.Code
{
    public class BotStore : Bot.Code.Bot
    {
        //private MarathonBotTaskProcessor TaskProcessor;


        public BotStore(TelegramBotClient client)
            : base("BotApplication.Data.States.", client, new StoreBotStateStorage(),
                new StoreBotCommandStorage())
        {
            //TaskProcessor = new MarathonBotTaskProcessor(this, AppConstants.RootDir + "\\log\\task_log.txt");
            //TaskProcessor.Start();
        }

    }
}