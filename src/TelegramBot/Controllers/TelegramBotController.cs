using System;
using System.Threading.Tasks;
using BotApplication.Bot.Abstract;
using BotApplication.Bot.Db.DbBot;
using BotApplication.BotStore.Code;
using BotApplication.BotStore.Mock;
using BotApplication.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BotApplication.Controllers
{
    [ApiController]
    public class TelegramBotController : ControllerBase
    {
        private static BotProcessController _controller;

        private static BotProcessController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = new StoreBotProcessController(BotSingleton.GetInstanceAsync().Result);
                }

                return _controller;
            }
        }

        
        [HttpGet("bot")]
        public async Task<ActionResult> GetBot()
        {
            //Get BotApplication client
            return Ok("BOT STARTED");
        }

        [HttpGet("test")]
        public async Task<ActionResult> Test()
        {
            return Ok("Test string");
        }
        
        [HttpGet("db")]
        public async Task<ActionResult> TestDb()
        {
            try
            {
                return Ok("Connect FALSE");
                // using (var db = new BotContext())
                // {
                //     if (db.Database.CanConnect())
                //     {
                //         return Ok("Connect TRUE");
                //     }
                //     else
                //     {
                //         return Ok("Connect FALSE");
                //     }
                // }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(AppConstants.DbConnection);
                return Ok("Connect FALSE");
            }
        }

        [HttpGet("mock")]
        public async Task<ActionResult> BootstrapMockDataToDatabase()
        {
            await MockBootstrap.BootstrapDatabase();
            return Ok("Database updated");
        }
        
        [HttpPost("/")]
        public async Task<IActionResult> Post(Telegram.Bot.Types.Update update)
        {
            if (update == null) return Ok();

            BotStore.Code.BotStore botStore = await BotSingleton.GetInstanceAsync();
            
            //На каждый запрос создаем отдельный контекст
            using (var botContext = new BotContext())
            {
                botStore.BotDbContext = botContext;
                await Controller.ProcessUpdate(botStore.client, update);
            }
            
            //Собираем мусор
            GC.Collect();
            return Ok();
        }
    }
}
