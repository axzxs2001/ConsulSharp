using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Session
{
    /// <summary>
    /// Read Session Result
    /// </summary>
    public class ReadSessionResult
    {
        /// <summary>
        /// LockDelay
        /// </summary>
        public double LockDelay { get; set; }
        /// <summary>
        /// Checks
        /// </summary>
        public string[] Checks { get; set; }
        /// <summary>
        /// Node
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// CreateIndex
        /// </summary>
        public long CreateIndex { get; set; }
    }
}
