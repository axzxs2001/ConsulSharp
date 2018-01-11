using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Transactions Back KV
    /// </summary>
    public class ResultKV
    {
        /// <summary>
        /// LockIndex
        /// </summary>
        public int LockIndex { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Flags
        /// </summary>
        public int Flags { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// CreateIndex
        /// </summary>
        public int CreateIndex { get; set; }
        /// <summary>
        /// ModifyIndex
        /// </summary>
        public int ModifyIndex { get; set; }
    }
}
