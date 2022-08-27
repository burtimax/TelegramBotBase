using System.Threading.Tasks;
using BotApplication.Bot.Code;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace BotApplication.BotStore.Data.States._TEMPLATE_
{
    public class _TEMPLATE_BotStateProcessor : BaseSantaStateProcessor
    {
        public _TEMPLATE_BotStateProcessor(UpdateBotModel dataForProcessing) : base(dataForProcessing)
        {
            RequiredMessageType = MessageType.Text;
        }

        protected override async Task<Hop> ProcessMessage(Message mes)
        {
            return successHop;
        }

        protected override Task<Hop> TextMessageProcess(Message mes)
        {
            return base.TextMessageProcess(mes);
        }
    }
}