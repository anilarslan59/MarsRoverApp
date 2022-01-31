using MarsRoverApp.Entity.Enums;
using MarsRoverApp.Entity.Models;
using MarsRoverProblemSolution.Repository.Interfaces;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveLeft : ICommand
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
                    coordinate.Direction = Direction.W;
                    break;

                case Direction.E:
                    coordinate.Direction = Direction.N;
                    break;

                case Direction.S:
                    coordinate.Direction = Direction.E;
                    break;

                case Direction.W:
                    coordinate.Direction = Direction.S;
                    break;
            }

            return coordinate;
        }
    }
}