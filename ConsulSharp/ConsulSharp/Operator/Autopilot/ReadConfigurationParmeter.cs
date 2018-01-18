using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Read Configuration Parmeter
    /// </summary>
    public class ReadConfigurationParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query string.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// If the cluster does not currently have a leader an error will be returned. You can use the ?stale query parameter to read the Raft configuration from any of the Consul servers.
        /// </summary>
        public bool Stale { get; set; }
    }
}
