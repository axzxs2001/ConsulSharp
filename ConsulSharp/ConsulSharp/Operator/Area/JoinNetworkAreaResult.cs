using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// Join Network Area Result
    /// </summary>
    public class JoinNetworkAreaResult
    {
        /// <summary>
        /// Address has the address requested to join.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Joined will be true if the Consul server at the given address was successfully joined into the network area. Otherwise, this will be false and Error will have a human-readable message about why the join didn't succeed.
        /// </summary>
        public bool Joined { get; set; }
        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}
