using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// List Nodes for Service parmeter
    /// </summary>
    public class NodeServiceParmeter:CheckServiceParmeter
    {
        /// <summary>
        /// Specifies the tag to filter the list. This is specifies as part of the URL as a query parameter.
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Specifies that the server should return only nodes with all checks in the passing state. This can be used to avoid additional filtering on the client side.
        /// </summary>
        public bool passing { get; set; }
    }
}
