using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Register Entity
    /// </summary>
    public class CatalogEntity
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// datacenter
        /// </summary>
        public string Datacenter { get; set; }

        /// <summary>
        /// node
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// taggedAddresses
        /// </summary>
        public TaggedAddress TaggedAddresses { get; set; }
        /// <summary>
        /// NodeMeta
        /// </summary>
        public object NodeMeta { get; set; }
        /// <summary>
        /// service
        /// </summary>
        public CatalogEntityService Service { get; set; }
        /// <summary>
        /// check
        /// </summary>
        public CatalogEntityCheck Check { get; set; }
        /// <summary>
        /// skip node update
        /// </summary>
        public bool SkipNodeUpdate { get; set; }
    }
}
