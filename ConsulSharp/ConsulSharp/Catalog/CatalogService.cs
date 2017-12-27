using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Catalog Service
    /// </summary>
    public class CatalogService
    {
        /// <summary>
        /// Node ID
        /// </summary>
        public string ID
        { get; set; }
        /// <summary>
        /// Node Name
        /// </summary>
        public string Node
        { get; set; }

        /// <summary>
        /// Node Address
        /// </summary>
        public string Address
        { get; set; }

        /// <summary>
        /// Datacenter
        /// </summary>
        public string Datacenter
        { get; set; }

        /// <summary>
        /// TaggedAddresses
        /// </summary>
        public TaggedAddress TaggedAddresses
        { get; set; }

        /// <summary>
        /// NodeMeta
        /// </summary>
        public object NodeMeta
        { get; set; }
               
        /// <summary>
        /// Service ID
        /// </summary>
        public string ServiceID
        { get; set; }
        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Service Tags
        /// </summary>
        public string[] ServiceTags { get; set; }

        /// <summary>
        /// Service Address
        /// </summary>
        public string ServiceAddress
        { get; set; }
        /// <summary>
        /// Service Port
        /// </summary>
        public int ServicePort
        { get; set; }

        /// <summary>
        /// Service Enable Tag Override
        /// </summary>
        public bool ServiceEnableTagOverride
        { get; set; }

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
