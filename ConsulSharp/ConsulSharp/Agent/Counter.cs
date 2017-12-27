using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// counter
    /// </summary>
    public class CounterSample
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// sum
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// min
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// max
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// mean
        /// </summary>
        public int Mean { get; set; }
        /// <summary>
        /// stddev
        /// </summary>
        public int Stddev { get; set; }

        /// <summary>
        /// labels
        /// </summary>
        public object Labels { get; set; }
    }
}
