using System.Collections.Generic;
using BotApplication.Bot.Code;
using BotApplication.BotStore.Data.States.Basket;
using BotApplication.BotStore.Data.States.Main;
using BotApplication.BotStore.Data.States.Start;

namespace BotApplication.BotStore.Data
{
    public class StoreBotStateStorage : BotStateStorage
    {
        protected override void InitStates()
        {
            this.States = new Dictionary<string, BotState>()
            {
                ["Start"] = new BotState()
                {
                    Name = "Start",
                    DefaultIntroductionString = StartVars.Introduction,
                    HopOnSuccess = new HopInfo("Main",
                        StartVars.Introduction),
                },
                ["Main"] = new BotState()
                {
                    Name = "Main",
                    DefaultIntroductionString = MainVars.Introduction,
                    //DefaultKeyboard = MainVars.DefaultKeyboardMarkup.Value,
                    HopOnSuccess = new HopInfo("Main",
                        MainVars.Introduction),
                    UnexpectedUpdateTypeAnswer = MainVars.Unexpected,
                },
                ["Basket"] = new BotState()
                {
                    Name = "Basket",
                    DefaultIntroductionString = BasketVars.Introduction,
                    DefaultKeyboard = BasketVars.BasketKeyboard().Value,
                    HopOnSuccess = new HopInfo("Basket",
                        BasketVars.Introduction),
                    UnexpectedUpdateTypeAnswer = BasketVars.Unexpected,
                },
            };
        }
    }
}