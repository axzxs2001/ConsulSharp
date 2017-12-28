using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Create ACL Token
    /// </summary>
    public class ACLToken
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// rules
        /// </summary>
        public string Rules { get; set; }
    }
}
