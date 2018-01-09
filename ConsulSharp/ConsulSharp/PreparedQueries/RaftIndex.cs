using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// RaftIndex
    /// </summary>
    public class RaftIndex
    {
        /// <summary>
        /// Create Index
        /// </summary>
        public int CreateIndex { get; set;}
        /// <summary>
        /// Modify Index
        /// </summary>
        public int ModifyIndex { get; set; }
    }
}
