using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.ACL
{
    /// <summary>
    /// Check ACL Replication
    /// </summary>
    public class ACLReplicationResult
    {
        /// <summary>
        /// reports whether ACL replication is enabled for the datacenter.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// reports whether the ACL replication process is running. The process may take approximately 60 seconds to begin running after a leader election occurs.
        /// </summary>
        public bool Running { get; set; }
        /// <summary>
        /// is the authoritative ACL datacenter that ACLs are being replicated from, and will match the acl_datacenter configuration.
        /// </summary>
        public string SourceDatacenter { get; set; }
        /// <summary>
        ///  is the last index that was successfully replicated. You can compare this to the X-Consul-Index header returned by the /v1/acl/list endpoint to determine if the replication process has gotten all available ACLs. Replication runs as a background process approximately every 30 seconds, and that local updates are rate limited to 100 updates/second, so so it may take several minutes to perform the initial sync of a large set of ACLs. After the initial sync, replica lag should be on the order of about 30 seconds.
        /// </summary>
        public int ReplicatedIndex { get; set; }
        /// <summary>
        /// is the UTC time of the last successful sync operation. Since ACL replication is done with a blocking query, this may not update for up to 5 minutes if there have been no ACL changes to replicate. A zero value of "0001-01-01T00:00:00Z" will be present if no sync has been successful.
        /// </summary>
        public string LastSuccess { get; set; }
        /// <summary>
        ///  is the UTC time of the last error encountered during a sync operation. If this time is later than LastSuccess, you can assume the replication process is not in a good state. A zero value of "0001-01-01T00:00:00Z" will be present if no sync has resulted in an error.
        /// </summary>
        public string LastError { get; set; }
    }
}
