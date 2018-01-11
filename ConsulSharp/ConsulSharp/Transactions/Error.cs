using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// OpIndex
        /// </summary>
        public int OpIndex { get; set; }
        /// <summary>
        /// What
        /// </summary>
        public string What { get; set; }
    }
}
