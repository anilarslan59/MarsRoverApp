using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Entity.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MoveRoverRequestModel
    {
        public List<string> SpaceSize { get; set; }
        public Coordinate CurrentCoordinate { get; set; }
        public string MovementCommand { get; set; }

    }
}
