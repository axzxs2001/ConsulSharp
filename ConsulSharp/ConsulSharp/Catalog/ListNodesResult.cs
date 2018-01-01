using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// Health Node
    /// </summary>
    public class ListNodesResult: BaseNode
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
