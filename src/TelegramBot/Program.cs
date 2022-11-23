using BotApplication.Bot.Db.DbBot;
using BotApplication.BotStore.Db.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BotApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();
            
            //CreateDatabase and Provide Migrations
            BotContext botContext = new BotContext();
            botContext.Database.EnsureCreated();
            
            StoreContext storeContext = new StoreContext();
            storeContext.Database.MigrateAsync();
            //

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

