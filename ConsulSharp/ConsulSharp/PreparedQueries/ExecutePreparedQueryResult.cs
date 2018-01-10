using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Execute Prepared Query Result
    /// </summary>
    public class ExecutePreparedQueryResult
    {
        /// <summary>
        /// Service has the service name that the query was selecting. This is useful for context in case an empty list of nodes is returned.
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// Nodes contains the list of healthy nodes providing the given service, as specified by the constraints of the prepared query.
        /// </summary>
        public ExecutePreparedQuery.Nodes[] Nodes { get; set; }
        /// <summary>
        /// DNS has information used when serving the results over DNS. This is just a copy of the structure given when the prepared query was created.
        /// </summary>
        public DNS DNS { get; set; }

        /// <summary>
        /// Datacenter has the datacenter that ultimately provided the list of nodes and Failovers has the number of remote datacenters that were queried while executing the query. This provides some insight into where the data came from. This will be zero during non-failover operations where there were healthy nodes found in the local datacenter.
        /// </summary>
        public string Datacenter { get; set; }

    }
}
