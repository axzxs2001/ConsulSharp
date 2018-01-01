using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// Deregister Entity Parmeter
    /// </summary>
    public class DeregisterEntityParmeter
    {
        /// <summary>
        ///  Specifies the datacenter, which defaults to the agent's datacenter if not provided.
        /// </summary>
        public string Datacenter { get; set; }
        /// <summary>
        /// Specifies the ID of the node. If no other values are provided, this node, all its services, and all its checks are removed.
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Specifies the ID of the check to remove.
        /// </summary>
        public string CheckID { get; set; }
        /// <summary>
        /// Specifies the ID of the service to remove. The service and all associated checks will be removed.
        /// </summary>
        public string ServiceID { get; set; }
    }
}
