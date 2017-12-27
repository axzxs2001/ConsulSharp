using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// Health Service
    /// </summary>
    public class HealthService
    {
        /// <summary>
        /// Service ID
        /// </summary>
        public string ID
        { get; set; }
        /// <summary>
        /// Service Name
        /// </summary>
        public string Service
        { get; set; }
        /// <summary>
        /// Service Tags
        /// </summary>
        public string[] Tags
        { get; set; }
        /// <summary>
        /// Service Address
        /// </summary>
        public string Address
        { get; set; }
        /// <summary>
        /// Service Port
        /// </summary>
        public int Port
        { get; set; }
        /// <summary>
        /// Service Enable Tag Override
        /// </summary>
        public bool EnableTagOverride
        { get; set; }
        /// <summary>
        /// Crete Index
        /// </summary>
        public int CreateIndex { get; set; }
        /// <summary>
        /// Modify Index
        /// </summary>
        public int ModifyIndex { get; set; }
    }
}
