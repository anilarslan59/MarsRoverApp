using MarsRoverApp.Entity.Enums;
using MarsRoverApp.Entity.Models;
using MarsRoverProblemSolution.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsRoverProblemSolution.Repository.Command
{
    public class MoveForward : ICommand
    {
        /// <summary>
        /// maximum space size
        /// </summary>
        private List<int> maxSpaceSize;

        /// <summary>
        /// constructor maxSpaceSize
        /// </summary>
        /// <param name="maxSpaceSize"></param>
        public MoveForward(List<int> maxSpaceSize)
        {
            this.maxSpaceSize = maxSpaceSize;
        }

        /// <summary>
        /// execute
        /// </summary>
        /// <returns></returns>
        public Coordinate Execute(Coordinate coordinate)
        {
            switch (coordinate.Direction)
            {
                case Direction.N:
                    if (coordinate.Y >= maxSpaceSize[1])
                        return null;
                    else
                        coordinate.Y += 1;
                    break;

                case Direction.E:
                    if (coordinate.X >= maxSpaceSize[0])
                        return null;
                    else
                        coordinate.X += 1;
                    break;

                case Direction.S:
                    if (coordinate.Y != 0)
                        coordinate.Y -= 1;
                    else
                        return null;
                    break;

                case Direction.W:
                    if (coordinate.X != 0)
                        coordinate.X -= 1;
                    else
                        return null;
                    break;
            }

            return coordinate;
        }
    }
}