using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// TTL Check Pass Parmeter
    /// </summary>
    public class TTLCheckPassParmeter
    {
        /// <summary>
        /// Specifies the unique ID of the check to use. This is specified as part of the URL.
        /// </summary>
        public string Check_ID { get; set; }

        /// <summary>
        /// Specifies a human-readable message. This will be passed through to the check's Output field.
        /// </summary>
        public string Note { get; set; }
    }
}
