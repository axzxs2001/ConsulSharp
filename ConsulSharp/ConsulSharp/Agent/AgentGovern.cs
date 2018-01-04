using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsulSharp.Agent.Check;
using ConsulSharp.Agent.Service;

namespace ConsulSharp.Agent
{
    /// <summary>
    /// Agent,Check,Service Govern
    /// </summary>
    public class AgentGovern : Govern
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public AgentGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        #region Agent

        /// <summary>
        /// List Members,This endpoint returns the members the agent sees in the cluster gossip pool. Due to the nature of gossip, this is eventually consistent: the results may differ by agent. The strongly consistent view of nodes is instead provided by /v1/catalog/nodes.
        /// </summary>
        /// <param name="listMembersParmeter">List Members Parmeter</param>
        /// <returns></returns>
        public async Task<Member[]> ListMembers(ListMembersParmeter listMembersParmeter)
        {
            return await Get<Member[], ListMembersParmeter>("/agent/members", listMembersParmeter);
        }

        /// <summary>
        /// This endpoint returns the configuration and member information of the local agent. The Config element contains a subset of the configuration and its format will not change in a backwards incompatible way between releases. DebugConfig contains the full runtime configuration but its format is subject to change without notice or deprecation.
        /// </summary>
        /// <returns></returns>
        public async Task<ReadConfigurationResult> ReadConfiguration()
        {
            return await Get<ReadConfigurationResult>("/agent/self");
        }

        /// <summary>
        /// This endpoint instructs the agent to reload its configuration. Any errors encountered during this process are returned.Not all configuration options are reloadable.See the Reloadable Configuration section on the agent options page for details on which options are supported.
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> ReloadAgent()
        {
            return await Put("", $"/agent/reload");
        }
        /// <summary>
        /// This endpoint places the agent into "maintenance mode". During maintenance mode, the node will be marked as unavailable and will not be present in DNS or API queries. This API call is idempotent.        Maintenance mode is persistent and will be automatically restored on agent restart.
        /// </summary>
        /// <param name="enableMaintenanceModeParmeter">Enable Maintenance Mode Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> EnableMaintenanceMode(EnableMaintenanceModeParmeter  enableMaintenanceModeParmeter)
        {
            return await Put(enableMaintenanceModeParmeter, $"/agent/maintenance");
        }

        /// <summary>
        /// This endpoint returns the configuration and member information of the local agent.
        /// </summary>
        /// <returns></returns>
        public async Task<ViewMetricsResult> ViewMetrics()
        {
            return await Get<ViewMetricsResult>("/agent/metrics");
        }
        /// <summary>
        /// WriteLog
        /// </summary>
        public event WriteLogHandle WriteLog;
        /// <summary>
        /// WriteLog Delegate
        /// </summary>
        /// <param name="log"></param>
        public delegate void WriteLogHandle(string log);
        /// <summary>
        /// This endpoint streams logs from the local agent until the connection is closed.Must subscription WriteLog event.
        /// </summary>
        /// <returns></returns>
        public async Task StreamLogs()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}");
            var stream = await client.GetStreamAsync("/agent/monitor");
            while (stream.CanRead)
            {
                var bytes = new byte[1024];
                var result = await stream.ReadAsync(bytes, 0, bytes.Length);
                WriteLog?.Invoke(Encoding.Default.GetString(bytes).Trim('\0'));
            }
        }
        /// <summary>
        /// This endpoint instructs the agent to attempt to connect to a given address.
        /// </summary>
        /// <param name="joinAgentParmeter">Join Agent Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> JoinAgent(JoinAgentParmeter joinAgentParmeter)
        {
            return await Put(joinAgentParmeter, $"/agent/join");
        }

        /// <summary>
        /// This endpoint triggers a graceful leave and shutdown of the agent. It is used to ensure other nodes see the agent as "left" instead of "failed". Nodes that leave will not attempt to re-join the cluster on restarting with a snapshot.For nodes in server mode, the node is removed from the Raft peer set in a graceful manner.This is critical, as in certain situations a non-graceful leave can affect cluster availability.
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> GracefulLeaveAndShutdown()
        {
            return await Put("", $"/agent/leave");
        }
        /// <summary>
        /// This endpoint instructs the agent to force a node into the left state. If a node fails unexpectedly, then it will be in a failed state. Once in the failed state, Consul will attempt to reconnect, and the services and checks belonging to that node will not be cleaned up. Forcing a node into the left state allows its old entries to be removed.
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> ForceLeaveAndShutdown()
        {
            return await Put("", $"/agent/force-leave");
        }

        /// <summary>
        /// This endpoint updates the ACL tokens currently in use by the agent. It can be used to introduce ACL tokens to the agent for the first time, or to update tokens that were initially loaded from the agent's configuration. Tokens are not persisted, so will need to be updated again if the agent is restarted.
        /// </summary>
        /// <param name="updateTokenParmeter">Update Token Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLToken(UpdateTokenParmeter updateTokenParmeter)
        {
            return await Put(updateTokenParmeter, $"/agent/acl_token");
        }
        /// <summary>
        ///  This endpoint updates the ACL tokens currently in use by the agent. It can be used to introduce ACL tokens to the agent for the first time, or to update tokens that were initially loaded from the agent's configuration. Tokens are not persisted, so will need to be updated again if the agent is restarted.
        /// </summary>
        /// <param name="updateTokenParmeter">Update Token Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentToken(UpdateTokenParmeter updateTokenParmeter)
        {
            return await Put(updateTokenParmeter, $"/agent/acl_agent_token");
        }
        /// <summary>
        ///  This endpoint updates the ACL tokens currently in use by the agent. It can be used to introduce ACL tokens to the agent for the first time, or to update tokens that were initially loaded from the agent's configuration. Tokens are not persisted, so will need to be updated again if the agent is restarted.
        /// </summary>
        /// <param name="updateTokenParmeter">Update Token Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentMasterToken(UpdateTokenParmeter updateTokenParmeter)
        {
            return await Put(updateTokenParmeter, $"/agent/acl_agent_master_token");
        }
        /// <summary>
        ///  This endpoint updates the ACL tokens currently in use by the agent. It can be used to introduce ACL tokens to the agent for the first time, or to update tokens that were initially loaded from the agent's configuration. Tokens are not persisted, so will need to be updated again if the agent is restarted.
        /// </summary>
        /// <param name="updateTokenParmeter">Update Token Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLReplicationToken(UpdateTokenParmeter updateTokenParmeter)
        {
            return await Put(updateTokenParmeter, $"/agent/acl_replication_token");
        }


        #endregion

        #region Check
        /// <summary>
        /// This endpoint returns all checks that are registered with the local agent. These checks were either provided through configuration files or added dynamically using the HTTP API.        It is important to note that the checks known by the agent may be different from those reported by the catalog.This is usually due to changes being made while there is no leader elected.The agent performs active anti-entropy, so in most situations everything will be in sync within a few seconds.
        /// </summary>
        /// <returns></returns>
        public async Task<ListChecksParmeter> ListChecks()
        {
            return await Get<ListChecksParmeter>("/agent/checks");
        }
        /// <summary>
        /// This endpoint adds a new check to the local agent. Checks may be of script, HTTP, TCP, or TTL type. The agent is responsible for managing the status of the check and keeping the Catalog in sync.
        /// </summary>
        /// <param name="registerCheckParmeter">Register Check Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> RegisterCheck(RegisterCheckParmeter registerCheckParmeter)
        {
            return await Put(registerCheckParmeter, $"/agent/check/register");
        }
        /// <summary>
        /// This endpoint remove a check from the local agent. The agent will take care of deregistering the check from the catalog. If the check with the provided ID does not exist, no action is taken.
        /// </summary>
        /// <param name="deregisterCheckParmeter">Deregister Check Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> DeregisterCheck(DeregisterCheckParmeter deregisterCheckParmeter )
        {
            return await Put(deregisterCheckParmeter, $"/agent/check/deregister");
        }
        /// <summary>
        /// This endpoint is used with a TTL type check to set the status of the check to passing and to reset the TTL clock.
        /// </summary>
        /// <param name="tTLCheckUpdateParmeter">TTL CheckUpdate Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckPass(TTLCheckPassParmeter  tTLCheckPassParmeter)
        {
            return await Put(tTLCheckPassParmeter, $"/agent/check/pass");
        }
        /// <summary>
        /// This endpoint is used with a TTL type check to set the status of the check to warning and to reset the TTL clock.
        /// </summary>
        /// <param name="tTLCheckPassParmeter">TTL Check Pass Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckWarn(TTLCheckPassParmeter tTLCheckPassParmeter)
        {
            return await Put(tTLCheckPassParmeter, $"/agent/check/warn");
        }
        /// <summary>
        /// This endpoint is used with a TTL type check to set the status of the check to critical and to reset the TTL clock.
        /// </summary>
        /// <param name="tTLCheckPassParmeter">TTL Check Pass Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckFail(TTLCheckPassParmeter tTLCheckPassParmeter)
        {
            return await Put(tTLCheckPassParmeter, $"/agent/check/fail");
        }
        /// <summary>
        /// This endpoint is used with a TTL type check to set the status of the check and to reset the TTL clock.
        /// </summary>
        /// <param name="tTLCheckUpdateParmeter">TTL Check Update Parmeter</param>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckUpdate(TTLCheckUpdateParmeter  tTLCheckUpdateParmeter)
        {
            return await Put(tTLCheckUpdateParmeter, $"/agent/check/update");
        }
        #endregion

        #region service
        /// <summary>
        /// This endpoint returns all the services that are registered with the local agent. These services were either provided through configuration files or added dynamically using the HTTP API.        It is important to note that the services known by the agent may be different from those reported by the catalog.This is usually due to changes being made while there is no leader elected.The agent performs active anti-entropy, so in most situations everything will be in sync within a few seconds.
        /// </summary>
        /// <returns></returns>    
        public async Task<Dictionary<string, ListService>> ListServices()
        {
            return await Get<Dictionary<string, ListService>>($"/agent/services");
        }

        /// <summary>
        /// This endpoint adds a new service, with an optional health check, to the local agent.        The agent is responsible for managing the status of its local services, and for sending updates about its local services to the servers to keep the global catalog in sync.
        /// </summary>
        /// <returns></returns>
        /// <param name="registerServiceParmeter">Register Service Parmeter</param>
        public async Task<(bool result, string backJson)> RegisterServices(RegisterServiceParmeter registerServiceParmeter)
        {
            return await Put(registerServiceParmeter, $"/agent/service/register");
        }
        /// <summary>
        /// This endpoint removes a service from the local agent. If the service does not exist, no action is taken.The agent will take care of deregistering the service with the catalog.If there is an associated check, that is also deregistered.
        /// </summary>
        /// <returns></returns>
        /// <param name="deregisterCheckParmeter">Deregister Check Parmeter</param>
        public async Task<(bool result, string backJson)> DeregisterServices(DeregisterCheckParmeter deregisterCheckParmeter)
        {
            return await Put(deregisterCheckParmeter, $"/agent/service/deregister");      
        }
        #endregion

    }
}
