using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Keyring
{
    /// <summary>
    /// List Gossip Encryption Keys Result
    /// </summary>
    public class ListGossipEncryptionKeysResult
    {
        /// <summary>
        /// WAN is true if the block refers to the WAN ring of that datacenter (rather than LAN).
        /// </summary>
        public bool WAN { get; set; }
        /// <summary>
        /// Datacenter is the datacenter the block refers to.
        /// </summary>
        public string Datacenter { get; set; }
        /// <summary>
        /// Segment is the network segment the block refers to.
        /// </summary>
        public string Segment { get; set; }
        /// <summary>
        /// Keys is a map of each gossip key to the number of nodes it's currently installed on.
        /// </summary>
        public Dictionary<string, int> Keys { get; set; }
        /// <summary>
        /// NumNodes is the total number of nodes in the datacenter.
        /// </summary>
        public int NumNodes { get; set; }
    }
}
