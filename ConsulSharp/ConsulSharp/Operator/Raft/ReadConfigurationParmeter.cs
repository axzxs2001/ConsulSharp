using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Raft
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
        /// If the cluster does not currently have a leader an error will be returned. You can use the ?stale query parameter to read the Raft configuration from any of the Consul servers. Not setting this will choose the default consistency mode which will forward the reqest to the leader for processing but not re-confirm the server is still the leader before returning results. See default consistency for more details.
        /// </summary>
        public bool Stale { get; set; }
    }
}
