using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// ttl check pass,warn,fail
    /// </summary>
    public class TTLCheckOpt
    {
        /// <summary>
        /// check id
        /// </summary>
        public string Check_ID { get; set; }

        /// <summary>
        /// note
        /// </summary>
        public string Note { get; set; }
    }
}
