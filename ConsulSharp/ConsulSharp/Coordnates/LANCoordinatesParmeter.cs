using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Coordinates
{
    /// <summary>
    /// Read LAN Coordinates for all nodes
    /// </summary>
    public class LANCoordinatesParmeter
    {
        /// <summary>
        /// Node
        /// </summary>
        public string Node
        { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC
        { get; set; }

        /// <summary>
        ///  (Enterprise-only) Specifies the segment to list members for. If left blank, this will query for the default segment when connecting to a server and the agent's own segment when connecting to a client (clients can only be part of one network segment). When querying a server, setting this to the special string _all will show members in all segments.
        /// </summary>
        public string Segment
        { get; set; }
    }
}
