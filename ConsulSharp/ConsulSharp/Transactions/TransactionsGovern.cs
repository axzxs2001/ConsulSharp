using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Transactions
{
    /// <summary>
    /// Transactions Govern
    /// </summary>
    public class TransactionsGovern : Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public TransactionsGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }
        /// <summary>
        /// This endpoint permits submitting a list of operations to apply to the KV store inside of a transaction. If any operation fails, the transaction is rolled back and none of the changes are applied.
        ///If the transaction does not contain any write operations then it will be fast-pathed internally to an endpoint that works like other reads, except that blocking queries are not currently supported.In this mode, you may supply the ?stale or ?consistent query parameters with the request to control consistency.To support bounding the acceptable staleness of data, read-only transaction responses provide the X-Consul-LastContact header containing the time in milliseconds that a server was last contacted by the leader node.The X-Consul-KnownLeader header also indicates if there is a known leader.These won't be present if the transaction contains any write operations, and any consistency query parameters will be ignored, since writes are always managed by the leader via the Raft consensus protocol.
        /// </summary>
        /// <param name="createTransactionParmeter">Create Transaction Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, CreateTransactionResult createTransactionResult)> CreateTransaction(CreateTransactionParmeter    createTransactionParmeter)
        {
            return await Put<CreateTransactionParmeter, CreateTransactionResult>(createTransactionParmeter, $"/txn");
        }
      
    }
}
