using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarsRoverApp.Entity.Settings;
using MarsRoverProblemSolution.Repository.Interfaces;
using MarsRoverProblemSolution.Repository.Process;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MarsRoverApp.Host
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddEnvironmentVariables();

                    if (args != null)
                        config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<RabbitMqSettings>(hostContext.Configuration.GetSection("RabbitMqSettings"));
                    services.RegisterMicroServices();
                    services.AddSingleton<IProcess, ExecuteAction>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });

            if (isService)
            {
                await builder.UseWindowsService().Build().RunAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }


    }
}