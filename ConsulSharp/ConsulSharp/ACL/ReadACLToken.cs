using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Read ACL Token
    /// </summary>
    public class ReadACLToken : ACLToken
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
