using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// node services
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// service name
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// service tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// port
        /// </summary>
        public int Port { get; set; }
    }
}
