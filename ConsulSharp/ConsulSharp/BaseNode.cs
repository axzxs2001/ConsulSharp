using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Health Node
    /// </summary>
    public class BaseNode
    {
        /// <summary>
        /// Node ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Node
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Datacenter
        /// </summary>
        public string Datacenter { get; set; }
        /// <summary>
        /// Tagged Addresses
        /// </summary>
        public TaggedAddress TaggedAddresses { get; set; }
        /// <summary>
        /// Meta
        /// </summary>
        public object Meta { get; set;} 
    }
}
