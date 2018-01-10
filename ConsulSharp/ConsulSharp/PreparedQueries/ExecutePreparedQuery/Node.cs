using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries.ExecutePreparedQuery
{
    /// <summary>
    /// 
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Node ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Node
        /// </summary>
        public string node { get; set; }
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
        /// Note Meta
        /// </summary>
        public object NoteMeta { get; set; }
    }
}
