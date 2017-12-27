using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// Query Health Service By Service Name
    /// </summary>
    public class QueryHealthService
    {
        /// <summary>
        /// Node
        /// </summary>
        public HealthCatalogNode Node { get; set; }
        /// <summary>
        /// Serice
        /// </summary>
        public HealthService Service { get; set; }
        /// <summary>
        /// Checks
        /// </summary>
        public HealthCheck[] Checks { get; set; }
    }
}
