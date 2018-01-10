using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries.ExecutePreparedQuery
{
    /// <summary>
    /// Nodes
    /// </summary>
    public class Nodes
    {
        /// <summary>
        /// Node
        /// </summary>
        public Node Node { get; set; }
        /// <summary>
        /// Service
        /// </summary>
        public Service Service { get; set; }
        /// <summary>
        /// Checks
        /// </summary>
        public Check[] Checks { get; set; }
    }
}
