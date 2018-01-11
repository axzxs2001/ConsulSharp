using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Snapshot
{
    /// <summary>
    /// Generate Snapshot Parmeter
    /// </summary>
    public class GenerateSnapshotParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        ///  Specifies that any follower may reply. By default requests are forwarded to the leader. Followers may be faster to respond, but may have stale data. To support bounding the acceptable staleness of snapshots, responses provide the X-Consul-LastContact header containing the time in milliseconds that a server was last contacted by the leader node. The X-Consul-KnownLeader header also indicates if there is a known leader. These can be used by clients to gauge the staleness of a snapshot and take appropriate action. The stale mode is particularly useful for taking a snapshot of a cluster in a failed state with no current leader.
        /// </summary>
        public bool Stale { get; set; }
    }
}
