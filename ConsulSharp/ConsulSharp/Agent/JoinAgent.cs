using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Join Agent Parmeter
    /// </summary>
    public class JoinAgentParmeter
    {
        /// <summary>
        /// Specifies the address of the other agent to join. This is specified as part of the URL.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Specifies to try and join over the WAN pool. This is only optional for agents running in server mode. This is specified as part of the URL as a query parameter
        /// </summary>
        public string Wan { get; set; }
    }
}
