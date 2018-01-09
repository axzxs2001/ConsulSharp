using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Failover
    /// </summary>
    public class Failover
    {
        /// <summary>
        /// Specifies that the query will be forwarded to up to NearestN other datacenters based on their estimated network round trip time using Network Coordinates from the WAN gossip pool. The median round trip time from the server handling the query to the servers in the remote datacenter is used to determine the priority. 
        /// </summary>
        public int NearestN { get; set; }
        /// <summary>
        /// Specifies a fixed list of remote datacenters to forward the query to if there are no healthy nodes in the local datacenter. Datacenters are queried in the order given in the list. If this option is combined with NearestN, then the NearestN queries will be performed first, followed by the list given by Datacenters. A given datacenter will only be queried one time during a failover, even if it is selected by both NearestN and is listed in Datacenters. 
        /// </summary>
        public string[] Datacenters { get; set; }
    }
}
