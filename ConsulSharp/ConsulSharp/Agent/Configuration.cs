using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Read Configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// config
        /// </summary>
        public Config Config { get; set; }

        /// <summary>
        /// debug config
        /// </summary>
        public object DebugConfig { get; set; }
        /// <summary>
        /// coord
        /// </summary>
        public Coord Coord { get; set; }
        /// <summary>
        /// member
        /// </summary>
        public Member Member { get; set; }

        /// <summary>
        /// meta
        /// </summary>
        public object Meta { get; set; }
    }
}
