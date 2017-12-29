using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.ACL
{
    /// <summary>
    /// ACL Govern
    /// </summary>
    public class ACLGovern: Govern
    {
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public ACLGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }
        /// <summary>
        /// Bootstrap ACLs,This endpoint does a special one-time bootstrap of the ACL system, making the first management token if the acl_master_token is not specified in the Consul server configuration, and if the cluster has not been bootstrapped previously. This is available in Consul 0.9.1 and later, and requires all Consul servers to be upgraded in order to operate.
        /// </summary>
        /// <returns></returns> 
        public async Task<(bool result, BootstrapACLsResult backBootstrapACLs)> BootstrapACLs()
        {
            return await Put<string,BootstrapACLsResult>("", $"/acl/bootstrap");
        }

        /// <summary>
        /// Create ACL Token,This endpoint makes a new ACL token.
        /// </summary>
        /// <returns></returns>
        /// <param name="aclToken">ACL Token Parmeter</param>
        public async Task<(bool result, BootstrapACLsResult backBootstrapACLs)> CreateACLToken(ACLTokenParmeter aclTokenParmeter)
        {
            return await Put< ACLTokenParmeter, BootstrapACLsResult>(aclTokenParmeter, $"/acl/create");
        }

        /// <summary>
        /// Update ACL Token,This endpoint is used to modify the policy for a given ACL token. Instead of generating a new token ID, the ID field must be provided.
        /// </summary>
        /// <returns></returns>
        /// <param name="aclTokenParmeter">ACL Token Parmeter</param>
        public async Task<(bool result, string backJson)> UpdateACLToken(ACLTokenParmeter aclTokenParmeter)
        {
            return await Put(aclTokenParmeter, $"/acl/update");
        }

        /// <summary>
        /// Delete ACL Token,This endpoint deletes an ACL token with the given ID.
        /// </summary>
        /// <returns></returns>
        /// <param name="uuid">Specifies the UUID of the ACL token to destroy. This is required and is specified as part of the URL path.</param>
        public async Task<(bool result, string backJson)> DeleteACLToken(string uuid)
        {
            return await Put("", $"/acl/destroy/{uuid}");
        }

        /// <summary>
        /// Read ACL Token,This endpoint reads an ACL token with the given ID.
        /// </summary>
        /// <param name="uuid">Specifies the UUID of the ACL token to read. This is required and is specified as part of the URL path.</param>
        /// <returns></returns>    
        public async Task<ReadACLTokenResult[]> ReadACLToken(string uuid)
        {
            return await Get<ReadACLTokenResult[]>($"/acl/info/{uuid}");
        }

        /// <summary>
        /// Clone ACL Token,This endpoint clones an ACL and returns a new token ID. This allows a token to serve as a template for others, making it simple to generate new tokens without complex rule management.
        /// </summary>
        /// <param name="uuid">Specifies the UUID of the ACL token to read. This is required and is specified as part of the URL path.</param>
        /// <returns></returns>    
        public async Task<(bool result, BootstrapACLsResult backJson)> CloneACLToken(string uuid)
        {
            return await Put<string, BootstrapACLsResult>("", $"/acl/clone/{uuid}");
        }

        /// <summary>
        /// List ACLs,his endpoint lists all the active ACL tokens.
        /// </summary>
        /// <returns></returns>    
        public async Task<ReadACLTokenResult[]> ListACLs()
        {
            return await Get<ReadACLTokenResult[]>($"/acl/list");
        }

        /// <summary>
        /// Check ACL Replication,This endpoint returns the status of the ACL replication process in the datacenter. This is intended to be used by operators, or by automation checking the health of ACL replication.
        /// </summary> 
        /// <param name="dc">Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.</param>
        /// <returns></returns>
        public async Task<ACLReplicationResult> CheckACLReplication(string dc)
        {
            return await Get<ACLReplicationResult>($"/acl/replication/{dc}");
        }

        
    }
}
