using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Read LAN Coordinates for all nodes
    /// </summary>
    public class LANCoordinatesParmeter
    {
        /// <summary>
        /// data center
        /// </summary>
        public string DC
        { get; set; }

        /// <summary>
        /// Segment
        /// </summary>
        public string Segment
        { get; set; }
    }
}
