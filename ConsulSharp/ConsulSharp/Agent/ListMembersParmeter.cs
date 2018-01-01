using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Agent
{
    /// <summary>
    /// List Members Parmeter
    /// </summary>
    public class ListMembersParmeter
    {
        /// <summary>
        /// Specifies to list WAN members instead of the LAN members (which is the default). This is only eligible for agents running in server mode. This is specified as part of the URL as a query parameter.
        /// </summary>
        public bool Wan { get; set; }
        /// <summary>
        ///  (Enterprise-only) Specifies the segment to list members for. If left blank, this will query for the default segment when connecting to a server and the agent's own segment when connecting to a client (clients can only be part of one network segment). When querying a server, setting this to the special string _all will show members in all segments.
        /// </summary>
        public string Segment { get; set; }
    }
}
