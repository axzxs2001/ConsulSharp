using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// List Network Area Members Result
    /// </summary>
    public class ListNetworkAreaMembersResult
    {
        /// <summary>
        /// ID is the node ID of the server.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name is the node name of the server, with its datacenter appended.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Addr is the IP address of the node.
        /// </summary>
        public string Addr { get; set; }
        /// <summary>
        /// Port is the server RPC port of the node.
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Datacenter is the node's Consul datacenter.
        /// </summary>
        public string Datacenter { get; set; }
        /// <summary>
        /// Role is always "server" since only Consul servers can participate in network areas.
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Build has the Consul version running on the node.
        /// </summary>
        public string Build { get; set; }
        /// <summary>
        /// Protocol is the protocol version being spoken by the node.
        /// </summary>
        public string Protocol { get; set; }
        /// <summary>
        /// Status is the current health status of the node, as determined by the network area distributed failure detector. This will be "alive", "leaving", "left", or "failed". A "failed" status means that other servers are not able to probe this server over its server RPC interface.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// RTT is an estimated network round trip time from the server answering the query to the given server, in nanoseconds. This is computed using network coordinates.
        /// </summary>
        public string RTT { get; set; }
    }
}
