using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// List Checks for Node
    /// </summary>
    public class  ListCheckForNodeParmeter
    {
        /// <summary>
        /// Specifies the name or ID of the node to query. This is specified as part of the URL
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
    }
}
