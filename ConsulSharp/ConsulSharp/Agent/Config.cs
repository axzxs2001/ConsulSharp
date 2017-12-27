using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// config
    /// </summary>
    public class Config
    {
        /// <summary>
        /// datacenter
        /// </summary>
        public string Datacenter
        { get; set; }
        /// <summary>
        /// node name
        /// </summary>
        public string NodeName
        { get; set; }
        /// <summary>
        /// is server
        /// </summary>
        public bool Server { get; set; }
        /// <summary>
        /// revision
        /// </summary>
        public string Revision { get; set; }
        /// <summary>
        /// version
        /// </summary>
        public string Version { get; set; }
    }
}
