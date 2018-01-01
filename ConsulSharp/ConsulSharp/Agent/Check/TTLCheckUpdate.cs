using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// TTL Check Update Parmeter
    /// </summary>
    public class TTLCheckUpdateParmeter
    {
        /// <summary>
        /// Specifies the unique ID of the check to use. This is specified as part of the URL.
        /// </summary>
        public string Check_ID
        { get; set; }
        /// <summary>
        /// Specifies the status of the check. Valid values are "passing", "warning", and "critical".
        /// </summary>
        public string Status
        { get; set; }
        /// <summary>
        /// Specifies a human-readable message. This will be passed through to the check's Output field.
        /// </summary>
        public string Output
        { get; set; }
    }
}
