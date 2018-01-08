using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Raft
{
    /// <summary>
    /// Read Configuration Result
    /// </summary>
    public class ReadConfigurationResult
    {
        /// <summary>
        /// Servers is has information about the servers in the Raft peer configuration:
        /// </summary>
        public Server[] Servers { get; set; }

        /// <summary>
        /// Index is the Raft corresponding to this configuration. The latest configuration may not yet be committed if changes are in flight.
        /// </summary>
        public int Index { get; set; }
    }
}
