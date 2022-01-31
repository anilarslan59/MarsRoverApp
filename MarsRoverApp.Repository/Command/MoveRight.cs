using MarsRoverApp.Entity.Enums;
using MarsRoverApp.Entity.Models;
using MarsRoverProblemSolution.Repository.Interfaces;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveRight : ICommand
    {
        /// <summary>
        /// execute
        /// </summary>
        /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate)
        {
            switch (coordinate.Direction)
            {
                case Direction.N:
                    coordinate.Direction = Direction.E;
                    break;

                case Direction.E:
                    coordinate.Direction = Direction.S;
                    break;

                case Direction.S:
                    coordinate.Direction = Direction.W;
                    break;

                case Direction.W:
                    coordinate.Direction = Direction.N;
                    break;
            }

            return coordinate;
        }
    }
}