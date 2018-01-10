using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries.ExplainPreparedQuery
{
    /// <summary>
    /// Explain Prepared Query Service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// service
        /// </summary>
        public string service { get; set; }
        /// <summary>
        /// Failover
        /// </summary>
        public Failover Failover { get; set; }
        /// <summary>
        /// OnlyPassing
        /// </summary>
        public bool OnlyPassing { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// NodeMeta
        /// </summary>
        public NodeMeta NodeMeta { get; set; }
    }
}
