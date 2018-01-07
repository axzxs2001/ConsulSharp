using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Read Health Result
    /// </summary>
    public class ReadHealthResult
    {
        /// <summary>
        /// Healthy is whether all the servers are currently healthy.
        /// </summary>
        public bool Healthy { get; set; }


        /// <summary>
        ///  FailureTolerance is the number of redundant healthy servers that could be fail without causing an outage(this would be 2 in a healthy cluster of 5 servers).
        /// </summary>
        public int FailureTolerance { get; set; }
        /// <summary>
        /// Servers holds detailed health information on each server:
        /// </summary>
        public Server[] Servers { get; set; }
    }
}
