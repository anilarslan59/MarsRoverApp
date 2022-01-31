using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MarsRoverApp.Entity.Extensions;
using MarsRoverApp.Entity.Models;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace MarsRoverApp
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
            var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true);

            var config = builder.Build();


            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var vh = config["RabbitMqSettings:VirtualHost"];
                var url = config["RabbitMqSettings:Host"];
                cfg.Durable = true;
                cfg.AutoDelete = false;
                var host = cfg.Host(url, vh, h =>
                {
                    h.Username(config["RabbitMqSettings:Username"]);
                    h.Password(config["RabbitMqSettings:Password"]);
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                Console.Write("Space size : ");
                var spaceSize = Console.ReadLine().Split(' ');

                var roverList = new List<MoveRoverRequestModel>();
                while(true)
                {
                    Console.Write("Rover coordinate : ");
                    var currentCoor = Console.ReadLine();

                    Console.Write("Rover movement command : ");
                    var movementCmd = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Do you want to add another rover? (Y/N) : ");
                    var anotherRover = Console.ReadLine();

                    var roverModel = new MoveRoverRequestModel
                    {
                        SpaceSize = spaceSize.ToList(),
                        CurrentCoordinate = currentCoor.ToRoverCoordinat(),
                        MovementCommand = movementCmd
                    };
                    roverList.Add(roverModel);

                    if (!anotherRover.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                }

                var client = busControl.CreateRequestClient<MoveRoverRequestModel>();


                foreach (var rover in roverList)
                {
                    var response = await client.GetResponse<MoveRoverResponseModel>(rover);

                    Console.WriteLine(response.Message.Coordinate.ToString());
                }

                Console.Write("Process completed.");
                Console.ReadLine();
            }
            finally
            {
                await busControl.StopAsync();
            }
        }


    }
}