using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Raft
{
    /// <summary>
    /// Raft Read Configuration Server Result
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Servers is has information about the servers in the Raft peer configuration:
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Node is the node name of the server, as known to Consul, or "(unknown)" if the node is stale and not known.
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Address is the IP:port for the server.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Leader is either "true" or "false" depending on the server's role in the Raft configuration.
        /// </summary>
        public bool Leader { get; set; }
        /// <summary>
        /// Voter is "true" or "false", indicating if the server has a vote in the Raft configuration. Future versions of Consul may add support for non-voting servers.
        /// </summary>
        public bool Voter { get; set; }
    }
}
