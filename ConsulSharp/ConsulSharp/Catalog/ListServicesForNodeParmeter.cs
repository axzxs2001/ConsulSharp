using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// List Services for Node Parmeter
    /// </summary>
    public class ListServicesForNodeParmeter
    {
        /// <summary>
        /// Specifies the name of the node for which to list services. This is specified as part of the URL.
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
    }
}
