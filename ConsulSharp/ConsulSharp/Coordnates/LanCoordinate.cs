using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Coordinates
{
    /// <summary>
    /// Coordinate
    /// </summary>
    public class Coordinate
    {
        /// <summary>
        /// Node
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// Segment
        /// </summary>
        public string Segment { get; set; }
        /// <summary>
        /// Coord
        /// </summary>
        public CoordnatesCoord Coord { get; set; }
    }
}
