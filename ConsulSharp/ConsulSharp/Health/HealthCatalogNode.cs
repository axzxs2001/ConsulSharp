using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Health Node
    /// </summary>
    public class HealthCatalogNode: BaseNode
    {       
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
