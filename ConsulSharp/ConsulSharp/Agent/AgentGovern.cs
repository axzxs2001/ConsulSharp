using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Agent
{
    /// <summary>
    /// Service Govern
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
        /// stream logs
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
                WritLog?.Invoke(Encoding.Default.GetString(bytes).Trim('\0'));
            }
        }
        /// <summary>
        /// join agent
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> JoinAgent(JoinAgent joinAgent)
        {
            return await Put(joinAgent, $"/agent/join");
        }

        /// <summary>
        /// graceful leave and shutdown
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> GracefulLeaveAndShutdown()
        {
            return await Put("", $"/agent/leave");
        }
        /// <summary>
        /// force leave and shutdown
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> ForceLeaveAndShutdown()
        {
            return await Put("", $"/agent/force-leave");
        }

        /// <summary>
        /// force leave and shutdown acl_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLToken(UpdateToken token)
        {
            return await Put(token, $"/agent/acl_token");
        }
        /// <summary>
        /// force leave and shutdown acl_agent_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentToken(UpdateToken token)
        {
            return await Put(token, $"/agent/acl_agent_token");
        }
        /// <summary>
        /// force leave and shutdown acl_agent_master_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentMasterToken(UpdateToken token)
        {
            return await Put(token, $"/agent/acl_agent_master_token");
        }
        /// <summary>
        /// force leave and shutdown acl_replication_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLReplicationToken(UpdateToken token)
        {
            return await Put(token, $"/agent/acl_replication_token");
        }
        public event WriteLogHandle WritLog;
        public delegate void WriteLogHandle(string log);

        #endregion

        #region Check
        /// <summary>
        /// view metrics
        /// </summary>
        /// <returns></returns>
        public async Task<QueryCheck> ListChecks()
        {
            return await Get<QueryCheck>("/agent/checks");
        }
        /// <summary>
        /// register check
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> RegisterCheck(RegisterCheck check)
        {
            return await Put(check, $"/agent/check/register");
        }
        /// <summary>
        /// deregister check
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> DeregisterCheck(string checkID)
        {
            return await Put("", $"/agent/check/deregister/{checkID}");
        }
        /// <summary>
        /// TTL check pass
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckPass(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/agent/check/pass");
        }
        /// <summary>
        /// TTL check warn
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckWarn(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/agent/check/warn");
        }
        /// <summary>
        /// TTL check fail
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckFail(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/agent/check/fail");
        }
        /// <summary>
        /// TTL check update
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckUpdate(TTLCheckUpdate checkUpdate)
        {
            return await Put(checkUpdate, $"/agent/check/update");
        }
        #endregion

        #region service
        /// <summary>
        /// List Services
        /// </summary>
        /// <returns></returns>    
        public async Task<Dictionary<string, ListService>> ListServices(TTLCheckOpt checkPass)
        {
            return await Get<Dictionary<string, ListService>>($"/agent/services");
        }

        /// <summary>
        /// register service
        /// </summary>
        /// <returns></returns>
        /// <param name="service">service</param>
        public async Task<(bool result, string backJson)> RegisterServices(Service service)
        {
            return await Put(service, $"/agent/service/register");
        }
        /// <summary>
        /// deregister service
        /// </summary>
        /// <returns></returns>
        /// <param name="serviceID">service ID</param>
        public async Task<(bool result, string backJson)> DeregisterServices(string serviceID)
        {
            return await Put("", $"/agent/service/deregister/{ serviceID}");
            //var client = new HttpClient();
            //client.BaseAddress = new Uri(_baseAddress);
            //var response = await client.PutAsync($"/agent/service/deregister/" + serviceID, null);
            //var backJson = await response.Content.ReadAsStringAsync();
            //return (result: response.StatusCode == System.Net.HttpStatusCode.OK, backJson: backJson);
        }
        #endregion

    }
}
