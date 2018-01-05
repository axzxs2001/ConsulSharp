using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// List Network Areas Parmeter
    /// </summary>
    public class ListNetworkAreasParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as a URL query parameter.
        /// </summary>
        public string DC { get; set; }
    }
}
