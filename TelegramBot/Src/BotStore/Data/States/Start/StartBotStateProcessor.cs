using System.Threading.Tasks;
using BotApplication.Bot.Code;
using BotApplication.BotStore.Data.States.Main;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApplication.BotStore.Data.States.Start
{
    public class StartBotStateProcessor : BaseSantaStateProcessor
    {
        public StartBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
        {
        }

        protected override async Task<Hop> ProcessMessage(Message mes)
        {
            await Bot.SendTextMessageAsync(Chat.Id, MainVars.Introduction, replyMarkup: MainVars.MainKeyboard.Value);

            Hop hop = new Hop(
                new HopInfo("Main", MainVars.Introduction, HopType.RootLevelHop, 
                    dynamicKeyboard:  MainVars.MainKeyboard.Value),
                CurrentState,
                StateStorage.Get("Main"));
            return hop;
        }

    }
}