using System;
using BotApplication.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BotApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            AppConstants.RootDir = env.WebRootPath;
            AppConstants.DbConnection = Configuration["Database:ConnectionString"];
            //logger.Log(LogLevel.Debug ,"DB connection - "+AppConstants.DbConnection);
            AppConstants.BotToken = Configuration["BotApplication:Token"];
            AppConstants.BotWebhook = Configuration["BotApplication:Webhook"];
            //logger.Log(LogLevel.Debug ,"BotApplication Webhook - "+AppConstants.BotWebhook);
            AppConstants.SupportUserId = Configuration["BotApplication:SupportUserId"];
            AppConstants.ShowDate = DateTime.ParseExact(Configuration["Constants:ShowDate"], "dd.MM.yyyy", null);
            
           
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var bot = BotSingleton.GetInstanceAsync().Result;
        }
    }
}
