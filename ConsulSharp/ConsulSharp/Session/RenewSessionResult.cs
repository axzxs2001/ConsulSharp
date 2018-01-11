using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Session
{
    /// <summary>
    /// Renew Session Result
    /// </summary>
    public class RenewSessionResult : ReadSessionResult
    {
        /// <summary>
        /// Behavior
        /// </summary>
        public string Behavior { get; set; }
        /// <summary>
        /// TTL
        /// </summary>
        public string TTL { get; set; }
    }
}
