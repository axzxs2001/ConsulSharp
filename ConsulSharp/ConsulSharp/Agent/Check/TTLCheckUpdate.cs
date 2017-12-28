using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// TTL Check Update
    /// </summary>
    public class TTLCheckUpdate
    {
        /// <summary>
        /// check id
        /// </summary>
        public string Check_ID
        { get; set; }
        /// <summary>
        /// status, passing, warning, critical.
        /// </summary>
        public string Status
        { get; set; }
        /// <summary>
        /// output
        /// </summary>
        public string Output
        { get; set; }
    }
}
