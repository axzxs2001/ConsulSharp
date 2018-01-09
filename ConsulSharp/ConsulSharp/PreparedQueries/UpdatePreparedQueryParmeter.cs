using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Update Prepared Query Parmeter
    /// </summary>
    public class UpdatePreparedQueryParmeter
    {
        /// <summary>
        /// Specifies the UUID of the query to update. This is required and is specified as part of the URL path.
        /// </summary>
        public string UUID { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
    }
}
