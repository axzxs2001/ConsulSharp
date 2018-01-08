using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Raft
{
    /// <summary>
    /// Delete Raft Peer Parmeter
    /// </summary>
    public class DeleteRaftPeerParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query string.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// SSpecifies the ID or address (IP:port) of the raft peer to remove.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Specifies the ID or address (IP:port) of the raft peer to remove.
        /// </summary>
        public string Address { get; set; }
    }
}
