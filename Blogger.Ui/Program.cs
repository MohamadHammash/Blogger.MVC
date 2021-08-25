using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Blogger.Data.Data;
using Blogger.Ui.HttpClientClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blogger.Ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            //YouTubeApiClient youTubeApiClient = new YouTubeApiClient(new HttpClient());
            //youTubeApiClient.Test();


            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        SeedData.InitAsync(services).Wait();
            //    }
            //    catch (Exception e)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(e.Message, "Seed Fail");
            //    }
            //}

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
