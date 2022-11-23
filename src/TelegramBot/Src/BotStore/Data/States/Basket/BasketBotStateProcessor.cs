using System.Threading.Tasks;
using BotApplication.Bot.Code;
using BotApplication.BotStore.Data.States.Main;
using BotApplication.BotStore.Db.Entities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotApplication.BotStore.Data.States.Basket
{
    public class BasketBotStateProcessor : BaseSantaStateProcessor
    {
        public BasketBotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
        {
            RequiredMessageType = MessageType.Text;
        }

        protected override async Task<Hop> ProcessMessage(Message mes)
        {
            string str = mes.Text;

            if (str == BasketVars.BasketBtn)
            {
                defaultHop.PriorityIntroduction = await BasketVars.GetBasketByUser(DbStore, CurrentUser.Id);
            }

            if (str == BasketVars.ClearBtn)
            {
                await DbStore.Repos.BasketRepository.ClearBasket(CurrentUser.Id);
                await DbStore.SaveChangesAsync();
                defaultHop.PriorityIntroduction = BasketVars.Cleared;
            }
            
            if (str == BasketVars.MainMenuBtn)
            {
                Hop hop = new Hop(
                    new HopInfo("Main", MainVars.Introduction, HopType.CurrentLevelHop,
                        dynamicKeyboard: MainVars.MainKeyboard.Value),
                    CurrentState,
                    StateStorage.Get("Main"));
                return hop;
            }
            
            if (str == BasketVars.OrderBtn)
            {
                (Order order, string desc) res = await DbStore.Repos.OrderRepository.CreateOrder(CurrentUser.Id);

                defaultHop.PriorityIntroduction = res.desc;
                
                if (res.order != null)
                {
                    await Bot.SendTextMessageAsync(AppConstants.SupportUserId,
                        await BasketVars.GetOrderDescription(DbStore, CurrentUser, res.order));
                }
                
            }
            
            return defaultHop;
        }

        protected override Task<Hop> TextMessageProcess(Message mes)
        {
            return base.TextMessageProcess(mes);
        }
    }
}