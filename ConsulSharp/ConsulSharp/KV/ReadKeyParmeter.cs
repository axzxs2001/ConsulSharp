using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.KV
{
    /// <summary>
    /// Read Key Parmeter
    /// </summary>
    public class ReadKeyParmeter
    {
        /// <summary>
        /// Specifies the path of the key to read.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        ///  Specifies if the lookup should be recursive and key treated as a prefix instead of a literal match. This is specified as part of the URL as a query parameter.
        /// </summary>
        public bool Recurse { get; set; }
        /// <summary>
        /// Specifies the response is just the raw value of the key, without any encoding or metadata. This is specified as part of the URL as a query parameter.
        /// </summary>
        public bool Raw { get; set; }
        /// <summary>
        /// Specifies to return only keys (no values or metadata). Specifying this implies recurse. This is specified as part of the URL as a query parameter.
        /// </summary>
        public bool Keys { get; set; }
        /// <summary>
        /// Specifies the character to use as a separator for recursive lookups. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Separator { get; set; }
    }
}
