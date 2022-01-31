using MarsRoverApp.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Entity.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Coordinate
    {
        /// x position
        public int X { get; set; }

        /// y position
        public int Y { get; set; }
                
        /// direction
        public Direction Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{X} {Y} {Direction.ToString()}";
        }
    }
}
