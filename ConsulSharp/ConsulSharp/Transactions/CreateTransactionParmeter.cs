using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Create Transaction Parmeter
    /// </summary>
    public class CreateTransactionParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }

        /// <summary>
        /// KV is the only available operation type, though other types may be added in the future.
        /// </summary>
        public KV KV { get; set; }
    }
}
