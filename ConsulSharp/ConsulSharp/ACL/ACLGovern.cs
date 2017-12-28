﻿using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp
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
        /// Bootstrap ACLs
        /// </summary>
        /// <returns></returns>
        /// <param name="id">id</param>
        public async Task<(bool result, string backJson)> BootstrapACLs(string id)
        {
            return await Put("", $"/acl/bootstrap/{id}");
        }

        /// <summary>
        /// Create ACL Token
        /// </summary>
        /// <returns></returns>
        /// <param name="aclToken">acl token</param>
        public async Task<(bool result, string backJson)> CreateACLToken(ACLToken aclToken)
        {
            return await Put(aclToken, $"/acl/create");
        }

        /// <summary>
        /// Update ACL Token
        /// </summary>
        /// <returns></returns>
        /// <param name="aclToken">acl token</param>
        public async Task<(bool result, string backJson)> UpdateACLToken(ACLToken aclToken)
        {
            return await Put(aclToken, $"/acl/update");
        }

        /// <summary>
        /// Delete ACL Token
        /// </summary>
        /// <returns></returns>
        /// <param name="id">id</param>
        public async Task<(bool result, string backJson)> DeleteACLToken(string id)
        {
            return await Put("", $"/acl/destroy/{id}");
        }

        /// <summary>
        /// Read ACL Token
        /// </summary>
        /// <returns></returns>    
        public async Task<ReadACLToken[]> ReadACLToken(string id)
        {
            return await Get<ReadACLToken[]>($"/acl/info/{id}");
        }

        /// <summary>
        /// Clone ACL Token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> CloneACLToken(string id)
        {
            return await Put("", $"/acl/clone/{id}");
        }

        /// <summary>
        /// List ACLs
        /// </summary>
        /// <returns></returns>    
        public async Task<ReadACLToken[]> ListACLs()
        {
            return await Get<ReadACLToken[]>($"/acl/list");
        }

        /// <summary>
        /// Check ACL Replication
        /// </summary> 
        /// <param name="datacenter">datacenter</param>
        /// <returns></returns>
        public async Task<ACLReplication> CheckACLReplication(string datacenter)
        {
            return await Get<ACLReplication>($"/acl/replication/{datacenter}");
        }

        
    }
}