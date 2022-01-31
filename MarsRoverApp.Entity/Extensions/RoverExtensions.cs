using MarsRoverApp.Entity.Enums;
using MarsRoverApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Entity.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class RoverExtensions
    {
        #region ToRoverCoordinat

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Coordinate ToRoverCoordinat(this string source)
        {
            var coordinateData = source.Split(' ');


            var coordinate = new Coordinate
            {
                X = Convert.ToInt32(coordinateData[0]),
                Y = Convert.ToInt32(coordinateData[1]),
                Direction = coordinateData[2].ToEnumValue<Direction>()
            };

            return coordinate;
        }

        #endregion ToRoverCoordinats
    }
}
