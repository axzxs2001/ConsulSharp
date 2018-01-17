using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// List Checks In State Parmeter
    /// </summary>
    public class ListChecksInStateParmeter
    {
        /// <summary>
        /// Specifies the state to query. Spported states are any, passing, warning, or critical. The any state is a wildcard that can be used to return all checks.
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifies a node name to sort the node list in ascending order based on the estimated round trip time from that node. Passing ?near=_agent will use the agent's node for the sort. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Near { get; set; }
        /// <summary>
        /// Specifies a desired node metadata key/value pair of the form key:value. This parameter can be specified multiple times, and will filter the results to nodes with the specified key/value pairs. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Node_Meta { get; set; }
    }
}
