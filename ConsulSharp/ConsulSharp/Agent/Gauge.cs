using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// gauge
    /// </summary>
    public class Gauge
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public long Value { get; set; }

        /// <summary>
        /// labels
        /// </summary>
        public object Labels { get; set; }
    }
}
