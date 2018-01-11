using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Session
{
    /// <summary>
    /// Delete Session Parmeter
    /// </summary>
    public class DeleteSessionParmeter
    {

        /// <summary>
        ///  Specifies the UUID of the session to destroy. This is required and is specified as part of the URL path.
        /// </summary>
        public string UUID { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter. Using this across datacenters is not recommended.
        /// </summary>
        public string DC { get; set; }
    }
}
