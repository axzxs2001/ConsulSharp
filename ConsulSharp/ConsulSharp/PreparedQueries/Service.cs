using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Service
    /// </summary>
    public class Service
    {
        /// <summary>
        ///  Specifies the name of the service to query. 
        /// </summary>
        public string service { get; set; }
        /// <summary>
        ///  contains two fields, both of which are optional, and determine what happens if no healthy nodes are available in the local datacenter when the query is executed. It allows the use of nodes in other datacenters with very little configuration. 
        /// </summary>
        public Failover Failover { get; set; }
        /// <summary>
        /// Specifies a node to sort near based on distance sorting using Network Coordinates. The nearest instance to the specified node will be returned first, and subsequent nodes in the response will be sorted in ascending order of estimated round-trip times. If the node given does not exist, the nodes in the response will be shuffled. Using _agent is supported, and will automatically return results nearest the agent servicing the request. If unspecified, the response will be shuffled by default.
        /// </summary>
        public string Near { get; set; }
        /// <summary>
        /// Specifies the behavior of the query's health check filtering. If this is set to false, the results will include nodes with checks in the passing as well as the warning states. If this is set to true, only nodes with checks in the passing state will be returned. 
        /// </summary>
        public bool OnlyPassing { get; set; }

        /// <summary>
        ///  Specifies a list of service tags to filter the query results. For a service to pass the tag filter it must have all of the required tags, and none of the excluded tags (prefixed with !). 
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        ///  Specifies a list of user-defined key/value pairs that will be used for filtering the query results to nodes with the given metadata values present. 
        /// </summary>
        public NodeMeta NodeMeta { get; set; }       

    }
}
