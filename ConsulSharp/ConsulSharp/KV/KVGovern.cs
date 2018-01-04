using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.KV
{
    /// <summary>
    /// Event Govern
    /// </summary>
    public class KVGovern: Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public KVGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }

        /// <summary>
        /// This endpoint returns the specified key. If no key exists at the given path, a 404 is returned instead of a 200 response.For multi-key reads, please consider using transaction.
        /// </summary>
        /// <param name="readKeyParmeter">Read Key Parmeter</param>
        /// <returns></returns>
        public async Task<ReadKeyResult[]> EventList(ReadKeyParmeter readKeyParmeter)
        {
            return await Get<ReadKeyResult[], ReadKeyParmeter>($"/kv", readKeyParmeter);
        }

        /// <summary>
        /// Even though the return type is application/json, the value is either true or false, indicating whether the create/update succeeded.The table below shows this endpoint's support for blocking queries, consistency modes, and required ACLs.
        /// </summary>
        /// <param name="firEventParmeter">Create Update Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, bool createUpdateResult)> CreateUpdateKey(CreateUpdateKeyParmeter  createUpdateKeyParmeter)
        {
            return await Put<CreateUpdateKeyParmeter, bool>(createUpdateKeyParmeter, $"/kv");
        }
        /// <summary>
        /// This endpoint deletes a single key or all keys sharing a prefix.
        /// </summary>
        /// <param name="deleteKeyParmeter">Delete Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, bool deleteResult)> DeleteKey(DeleteKeyParmeter  deleteKeyParmeter)
        {
            return await Delete<DeleteKeyParmeter, bool>(deleteKeyParmeter, $"/kv");
        }
    }
}
