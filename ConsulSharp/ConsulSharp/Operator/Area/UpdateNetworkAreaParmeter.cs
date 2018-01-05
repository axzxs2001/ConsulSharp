using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// Update Network Area Parmeter
    /// </summary>
    public class UpdateNetworkAreaParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as a URL query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifies whether gossip over this area should be encrypted with TLS if possible.
        /// </summary>
        public bool UseTLS { get; set; }
    }
}
