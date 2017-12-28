using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Fire Event
    /// </summary>
    public class FireEvent
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
        /// payload
        /// </summary>
        public string Payload { get; set; }
        /// <summary>
        /// node filter
        /// </summary>
        public string NodeFilter { get; set; }
        /// <summary>
        /// service filter
        /// </summary>
        public string ServiceFilter { get; set; }
        /// <summary>
        /// tag filter
        /// </summary>
        public string TagFilter { get; set; }
        /// <summary>
        /// version
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// ltime
        /// </summary>
        public int LTime { get; set; }
    }
}
