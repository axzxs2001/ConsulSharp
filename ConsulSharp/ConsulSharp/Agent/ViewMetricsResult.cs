using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// View Metrics Result
    /// </summary>
    public class ViewMetricsResult
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
        public Counter[] Counters { get; set; }
        /// <summary>
        /// samples
        /// </summary>
        public Sample[] Samples { get; set; }

    }
}
