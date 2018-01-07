using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Read Health Parmeter
    /// </summary>
    public class ReadHealthParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query string.
        /// </summary>
        public string DC { get; set; }
    }
}
