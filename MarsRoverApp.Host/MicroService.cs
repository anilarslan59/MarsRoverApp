using MarsRoverApp.Entity.Settings;
using MarsRoverApp.Services.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

namespace MarsRoverApp.Host
{
    public static class MicroService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void RegisterMicroServices(this IServiceCollection services)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<MoveRoverConsumer>();

                cfg.AddBus(ConfigureBus);
            });

            services.AddSingleton<IPublishEndpoint>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<ISendEndpointProvider>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        static IBusControl ConfigureBus(IServiceProvider provider)
        {
            var appConfig = provider.GetRequiredService<IOptions<RabbitMqSettings>>().Value;

            var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Durable = true;
                var vh = appConfig.VirtualHost;
                var url = appConfig.Host;

                var host = cfg.Host(url, vh, h =>
                {
                    h.Username(appConfig.Username);
                    h.Password(appConfig.Password);
                });


                cfg.ConfigureEndpoints(provider);
            });

            return bus;
        }
    }
}
