using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Read Prepared Query Parmeter
    /// </summary>
    public class ReadPreparedQueryParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter. 
        /// </summary>
        public string DC { get; set; }
    }
}
