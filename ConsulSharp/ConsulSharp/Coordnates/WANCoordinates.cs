using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Read WAN Coordinates
    /// </summary>
    public class WANCoordinates
    {
        /// <summary>
        /// datacenter
        /// </summary>
        public string Datacenter { get; set; }

        /// <summary>
        /// area id
        /// </summary>
        public string AreaID { get; set; }

        /// <summary>
        /// Coordinates
        /// </summary>
        public Coordinate[] Coordinates { get; set; }
    }
}
