using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// List Nodes For Service Result
    /// </summary>
    public class ListNodesForServiceResult
    {
        /// <summary>
        /// ID
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
        /// TaggedAddres
        /// </summary>
        public TaggedAddress TaggedAddresses { get; set; }
        /// <summary>
        /// Node Meta
        /// </summary>
        public object NodeMeta { get; set; }

        /// <summary>
        /// Create Index
        /// </summary>
        public int CreateIndex { get; set; }

        /// <summary>
        /// Modify Index
        /// </summary>
        public int ModifyIndex { get; set; }

        /// <summary>
        /// Service Address
        /// </summary>
        public string ServiceAddress { get; set; }
        /// <summary>
        /// Service Enable Tag Override
        /// </summary>
        public bool ServiceEnableTagOverride { get; set; }

        /// <summary>
        /// Service ID
        /// </summary>
        public string ServiceID { get; set; }
        /// <summary>
        /// Service Name
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Service Port
        /// </summary>
        public int ServicePort { get; set; }

        /// <summary>
        /// Service Tags
        /// </summary>
        public string[] ServiceTags { get; set; }

    }
}
