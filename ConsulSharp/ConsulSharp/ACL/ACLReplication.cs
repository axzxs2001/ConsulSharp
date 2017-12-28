using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Check ACL Replication
    /// </summary>
    public class ACLReplication
    {
        /// <summary>
        /// enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// running
        /// </summary>
        public bool Running { get; set; }
        /// <summary>
        /// source datacenter
        /// </summary>
        public string SourceDatacenter { get; set; }
        /// <summary>
        /// replicated index
        /// </summary>
        public int ReplicatedIndex { get; set; }
        /// <summary>
        /// last success
        /// </summary>
        public string LastSuccess { get; set; }
        /// <summary>
        /// last error
        /// </summary>
        public string LastError { get; set; }
    }
}
