using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries.ExecutePreparedQuery
{
    /// <summary>
    /// ExecutePreparedQuery Result Service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// service
        /// </summary>
        public string service { get; set; }
        /// <summary>
        /// Tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
    }
}
