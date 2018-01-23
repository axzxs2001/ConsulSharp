using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Session
{
    /// <summary>
    /// List Sessions Parmeter
    /// </summary>
    public class ListSessionsParmeter
    {
        /// <summary>
        ///  Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter. Using this across datacenters is not recommended.
        /// </summary>
        public string DC { get; set; }  
    }
}
