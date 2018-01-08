using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsulSharp.Operator.Area;
using ConsulSharp.Operator.Autopilot;
using ConsulSharp.Operator.Keyring;
namespace ConsulSharp.Operator.Raft
{
    /// <summary>
    /// Operator Raft Govern
    /// </summary>
    public class OperatorRaftGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorRaftGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint reads the current raft configuration.
        /// </summary>
        /// <param name="readConfigurationParmeter"></param>
        /// <returns></returns>
        public async Task<ReadConfigurationResult> ReadConfiguration(ReadConfigurationParmeter  readConfigurationParmeter)
        {
            return await Get<ReadConfigurationResult, ReadConfigurationParmeter>("/operator/raft/configuration", readConfigurationParmeter);
        }

        /// <summary>
        /// This endpoint removes the Consul server with given address from the Raft configuration.There are rare cases where a peer may be left behind in the Raft configuration even though the server is no longer present and known to the cluster.This endpoint can be used to remove the failed server so that it is no longer affects the Raft quorum.If ACLs are enabled, the client will need to supply an ACL Token with operator write privileges.
        /// </summary>
        /// <param name="deleteRaftPeerParmeter">Delete Raft Peer Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> DeleteGossipEncryptionKey(DeleteRaftPeerParmeter  deleteRaftPeerParmeter)
        {
            return await Delete<DeleteRaftPeerParmeter, string>(deleteRaftPeerParmeter, "	/operator/raft/peer");
        }
    }
}
