using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotTools.Controller
{
    interface IUpdateProcessController
    {
        public TelegramBotClient bot { get; set; }

        Task ProcessUpdateAsync();
    }
}
