using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// List Services for Node
    /// </summary>
    public class CatalogNode
    {
        /// <summary>
        /// node
        /// </summary>
        public BaseNode Node { get; set; }
        /// <summary>
        /// services
        /// </summary>
        public Dictionary<string, BaseService> Services { get; set; }
    }
}
