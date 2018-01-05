using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// List Network Areas Result
    /// </summary>
    public class ListNetworkAreasResult
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Peer Datacenter
        /// </summary>
        public string PeerDatacenter { get; set; }
        /// <summary>
        /// Retry Join
        /// </summary>
        public string[] RetryJoin { get; set; }

    }
}
