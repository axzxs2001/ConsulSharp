using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Health Check
    /// </summary>
    public class HealthCheck
    {
        /// <summary>
        /// Node Name
        /// </summary>
        public string Node
        { get; set; }
        /// <summary>
        /// Check ID
        /// </summary>
        public string CheckID
        { get; set; }
        /// <summary>
        /// Check Name
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Check Status(passing, warning, or critical)
        /// </summary>
        public string Status
        { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes
        { get; set; }

        /// <summary>
        /// Output
        /// </summary>
        public string Output
        { get; set; }
        /// <summary>
        /// Service ID
        /// </summary>
        public string ServiceID
        { get; set; }
        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Service Tags
        /// </summary>
        public string[] ServiceTags { get; set; }
        /// <summary>
        /// Definition
        /// </summary>
        public object Definition { get; set; }
        /// <summary>
        /// Create Index
        /// </summary>
        public int CreateIndex { get; set; }
        /// <summary>
        /// Modify Index
        /// </summary>
        public int ModifyIndex { get; set; }
    }
}
