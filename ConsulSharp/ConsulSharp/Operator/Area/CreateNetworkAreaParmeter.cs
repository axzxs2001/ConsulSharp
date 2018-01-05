using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// Create Network Area Parmter
    /// </summary>
    public class CreateNetworkAreaParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as a URL query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifes the name of the Consul datacenter that will be joined the Consul servers in the current datacenter to form the area.Only one area is allowed for each possible PeerDatacenter, and a datacenter cannot form an area with itself.
        /// </summary>
        public string PeerDatacenter { get; set; }
        /// <summary>
        /// Specifies a list of Consul servers to attempt to join. Servers can be given as IP, IP:port, hostname, or hostname:port. Consul will spawn a background task that tries to periodically join the servers in this list and will run until a join succeeds. If this list is not supplied, joining can be done with a call to the join endpoint once the network area is created.
        /// </summary>
        public string[] RetryJoin { get; set; }
        /// <summary>
        /// Specifies whether gossip over this area should be encrypted with TLS if possible.
        /// </summary>
        public bool UseTLS { get; set; }
    }
}
