using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// View Metrics
    /// </summary>
    public class Metrics
    {
        /// <summary>
        /// timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// gauges
        /// </summary>
        public Gauge[] Gauges { get; set; }
        /// <summary>
        /// points
        /// </summary>
        public double[] Points { get; set; }
        /// <summary>
        /// counters
        /// </summary>
        public CounterSample[] Counters { get; set; }
        /// <summary>
        /// samples
        /// </summary>
        public CounterSample[] Samples { get; set; }

    }
}
