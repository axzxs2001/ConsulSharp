using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Checks for Node
    /// </summary>
    public class BaseCheckNode
    {       
        /// <summary>
        /// node
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// check id
        /// </summary>
        public string CheckID { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// output
        /// </summary>
        public string Output { get; set; }
        /// <summary>
        /// service id
        /// </summary>
        public string ServiceID { get; set; }
        /// <summary>
        /// service name
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// service tags
        /// </summary>
        public string[] ServiceTags { get; set; }
    }
}
