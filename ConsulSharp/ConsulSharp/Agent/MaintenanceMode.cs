using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Maintenance Mode
    /// </summary>
    public class MaintenanceMode
    {
        /// <summary>
        /// enable
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// reason
        /// </summary>
        public string Reason { get; set; }
    }
}
