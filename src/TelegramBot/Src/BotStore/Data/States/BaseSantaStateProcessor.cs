using BotApplication.Bot.Abstract;
using BotApplication.Bot.Code;
using BotApplication.BotStore.Db.Context;

namespace BotApplication.BotStore.Data.States
{
    public class BaseSantaStateProcessor : BotUpdateProcessor
    {
        protected StoreContext DbStore;
        
        public BaseSantaStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
        {
            this.DbStore = new StoreContext();
        }
    }
}