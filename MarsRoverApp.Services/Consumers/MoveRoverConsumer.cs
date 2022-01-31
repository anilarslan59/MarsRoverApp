using MarsRoverApp.Entity.Models;
using MarsRoverProblemSolution.Repository.Command;
using MarsRoverProblemSolution.Repository.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarsRoverApp.Services.Consumers
{
    /// <summary>
    /// 
    /// </summary>
    public class MoveRoverConsumer : IConsumer<MoveRoverRequestModel>
    {

        IProcess _process;

        /// <summary>
        /// 
        /// </summary>
        public MoveRoverConsumer(IProcess process)
        {
            _process = process;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<MoveRoverRequestModel> context)
        {
            var response = new MoveRoverResponseModel();
            var message = context.Message;

            var maxSpaceSize = new List<int>();
            foreach (var size in message.SpaceSize)
            {
                var maxCoordinate = Convert.ToInt32(size);
                maxSpaceSize.Add(maxCoordinate);
            }

            ICommand cmd = null;
            foreach (var direction in message.MovementCommand)
            {
                switch (direction)
                {
                    case 'L':
                        cmd = new MoveLeft();
                        break;

                    case 'R':
                        cmd = new MoveRight();
                        break;

                    case 'M':
                        cmd = new MoveForward(maxSpaceSize);
                        break;

                    default:
                         await context.RespondAsync(response);
                        break;
                }
                var coor = _process.Execute(cmd, message.CurrentCoordinate);

                if (coor == null)
                     await context.RespondAsync(response);

                message.CurrentCoordinate.Direction = coor.Direction;
                message.CurrentCoordinate.X = coor.X;
                message.CurrentCoordinate.Y = coor.Y;
            }

            response.Coordinate = message.CurrentCoordinate;
            
            await context.RespondAsync(response);
        }
    }
}
