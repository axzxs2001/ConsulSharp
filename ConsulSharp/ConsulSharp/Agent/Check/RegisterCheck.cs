using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
    /// <summary>
    /// register Check
    /// </summary>
    public class RegisterCheck
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// notes
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// deregister critical service after
        /// </summary>
        public string DeregisterCriticalServiceAfter { get; set; }
        /// <summary>
        /// args
        /// </summary>
        public string[] Args { get; set; }
        /// <summary>
        /// docker container id
        /// </summary>
        public string DockerContainerID { get; set; }
        /// <summary>
        /// shell
        /// </summary>
        public string Shell { get; set; }
        /// <summary>
        /// http
        /// </summary>
        public string HTTP { get; set; }
        /// <summary>
        /// method
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// header
        /// </summary>
        public object Header { get; set; }
        /// <summary>
        /// tcp
        /// </summary>
        public string TCP { get; set; }
        /// <summary>
        /// interval
        /// </summary>
        public string Interval { get; set; }
        /// <summary>
        /// ttl
        /// </summary>
        public string TTL { get; set; }
        /// <summary>
        /// tls skip verify
        /// </summary>
        public string TLSSkipVerify { get; set; }
    }
}
