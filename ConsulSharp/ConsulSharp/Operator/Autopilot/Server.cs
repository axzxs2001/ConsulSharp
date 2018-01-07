using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Read Health Server
    /// </summary>
    public class Server
    {
        /// <summary>
        /// ID is the Raft ID of the server.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name is the node name of the server.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Address is the address of the server.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// SerfStatus is the SerfHealth check status for the server.
        /// </summary>
        public string SerfStatus { get; set; }
        /// <summary>
        /// Version is the Consul version of the server.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// Leader is whether this server is currently the leader.
        /// </summary>
        public bool Leader { get; set; }
        /// <summary>
        /// LastContact is the time elapsed since this server's last contact with the leader.
        /// </summary>
        public string LastContact { get; set; }
        /// <summary>
        /// LastTerm is the server's last known Raft leader term.
        /// </summary>
        public int LastTerm { get; set; }
        /// <summary>
        /// LastIndex is the index of the server's last committed Raft log entry.
        /// </summary>
        public int LastIndex { get; set; }
        /// <summary>
        /// Healthy is whether the server is healthy according to the current Autopilot configuration.
        /// </summary>
        public bool Healthy { get; set; }
        /// <summary>
        /// Voter is whether the server is a voting member of the Raft cluster.
        /// </summary>
        public bool Voter { get; set; }
        /// <summary>
        /// StableSince is the time this server has been in its current Healthy state.
        /// </summary>
        public string StableSince { get; set; }
    }
}
