using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// coord
    /// </summary>
    public class Coord
    {
        /// <summary>
        /// adjustment
        /// </summary>
        public int Adjustment { get; set; }
        /// <summary>
        /// error
        /// </summary>
        public double Error { get; set; }
        /// <summary>
        /// vec
        /// </summary>
        public int[] Vec { get; set; }
    }
}
