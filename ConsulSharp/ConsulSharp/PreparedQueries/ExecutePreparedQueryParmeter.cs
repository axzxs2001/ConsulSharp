using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// ExecutePreparedQueryParmeter
    /// </summary>
    public class ExecutePreparedQueryParmeter
    {
        /// <summary>
        /// Specifies the UUID of the query to execute. This is required and is specified as part of the URL path. This can also be the name of an existing prepared query, or a name that matches a prefix name for a prepared query template.
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }

        /// <summary>
        /// Specifies to sort the resulting list in ascending order based on the estimated round trip time from that node. Passing ?near=_agent will use the agent's node for the sort. If this is not present, the default behavior will shuffle the nodes randomly each time the query is executed.
        /// </summary>
        public string Near { get; set; }

        /// <summary>
        ///  Limit the size of the list to the given number of nodes. This is applied after any sorting or shuffling.
        /// </summary>
        public int Limit { get; set; }
    }
}
