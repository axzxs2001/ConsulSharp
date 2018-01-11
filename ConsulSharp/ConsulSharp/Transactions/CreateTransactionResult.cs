using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Create Transaction Result
    /// </summary>
    public class CreateTransactionResult
    {
        /// <summary>
        /// Result
        /// </summary>
        public Result[] Results{get;set;}

        /// <summary>
        /// Error
        /// </summary>
        public Error[] Errors { get; set; }
    }
}
