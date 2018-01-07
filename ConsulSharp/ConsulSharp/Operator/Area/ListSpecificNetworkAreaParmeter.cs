using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// List Specific Network Area Parmeter
    /// </summary>
    public class ListSpecificNetworkAreaParmeter
    {
        /// <summary>
        /// Specifies the UUID of the area to list. This is specified as part of the URL.
        /// </summary>
        public string UUID { get; set;}
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as a URL query parameter.
        /// </summary>
        public string DC { get; set; }
    }
}
