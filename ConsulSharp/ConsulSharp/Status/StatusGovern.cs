using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Status
{
    /// <summary>
    /// Status Govern
    /// </summary>
    public class StatusGovern : Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public StatusGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }

        /// <summary>
        /// This endpoint returns the Raft leader for the datacenter in which the agent is running.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetRaftLeader()
        {
            return await Get<string>($"/status/leader");
        }
        /// <summary>
        /// This endpoint retrieves the Raft peers for the datacenter in which the the agent is running. This list of peers is strongly consistent and can be useful in determining when a given server has successfully joined the cluster.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> ListRaftPeers()
        {
            return await Get<string[]>($"/status/peers");
        }
    }
}
