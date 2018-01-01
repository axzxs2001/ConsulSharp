using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Enable Maintenance Mode Parmeter
    /// </summary>
    public class EnableMaintenanceModeParmeter
    {
        /// <summary>
        /// Specifies whether to enable or disable maintenance mode. This is specified as part of the URL as a query string parameter.
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Specifies a text string explaining the reason for placing the node into maintenance mode. This is simply to aid human operators. If no reason is provided, a default value will be used instead. This is specified as part of the URL as a query string parameter, and, as such, must be URI-encoded.
        /// </summary>
        public string Reason { get; set; }
    }
}
