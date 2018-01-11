using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Transactions KV
    /// </summary>
    public class KV
    {
        /// <summary>
        /// Specifies the type of operation to perform.Please see the table below for available verbs.
        /// </summary>
        public string Verb { get; set; }
        /// <summary>
        /// Specifies the full path of the entry.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Specifies a base64-encoded blob of data.Values cannot be larger than 512kB.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Specifies an opaque unsigned integer that can be attached to each entry.Clients can choose to use this however makes sense for their application. Index(int: 0) - Specifies an index.See the table below for more information.
        /// </summary>
        public int Flags { get; set; }
        /// <summary>
        ///Specifies a session.See the table below for more information.
        /// </summary>
        public string Session { get; set; }

    }
}
