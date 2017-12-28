using ConsulSharp.Health;
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
        /// get agent members
        /// </summary>
        /// <returns></returns>
        public async Task<Member[]> Members()
        {
            return await Get<Member[]>("/v1/agent/members");
        }

        /// <summary>
        /// get agent configuration
        /// </summary>
        /// <returns></returns>
        public async Task<Configuration> Configuration()
        {
            return await Get<Configuration>("/v1/agent/self");
        }

        /// <summary>
        /// reload agent
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> ReloadAgent()
        {
            return await Put("", $"/v1/agent/reload");
        }
        /// <summary>
        /// enable maintenance mode
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> EnableMaintenanceMode(MaintenanceMode maintenanceMode)
        {
            return await Put(maintenanceMode, $"/v1/agent/maintenance");
        }

        /// <summary>
        /// view metrics
        /// </summary>
        /// <returns></returns>
        public async Task<Metrics> ViewMetrics()
        {
            return await Get<Metrics>("/v1/agent/metrics");
        }
        /// <summary>
        /// stream logs
        /// </summary>
        /// <returns></returns>
        public async Task StreamLogs()
        {         
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}");        
            var stream = await client.GetStreamAsync("/v1/agent/monitor");
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
            return await Put(joinAgent, $"/v1/agent/join");
        }

        /// <summary>
        /// graceful leave and shutdown
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> GracefulLeaveAndShutdown()
        {
            return await Put("", $"/v1/agent/leave");
        }
        /// <summary>
        /// force leave and shutdown
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> ForceLeaveAndShutdown()
        {
            return await Put("", $"/v1/agent/force-leave");
        }

        /// <summary>
        /// force leave and shutdown acl_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLToken(UpdateToken token)
        {
            return await Put(token, $"/v1/agent/acl_token");
        }
        /// <summary>
        /// force leave and shutdown acl_agent_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentToken(UpdateToken token)
        {
            return await Put(token, $"/v1/agent/acl_agent_token");
        }
        /// <summary>
        /// force leave and shutdown acl_agent_master_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLAgentMasterToken(UpdateToken token)
        {
            return await Put(token, $"/v1/agent/acl_agent_master_token");
        }
        /// <summary>
        /// force leave and shutdown acl_replication_token
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> UpdateACLReplicationToken(UpdateToken token)
        {
            return await Put(token, $"/v1/agent/acl_replication_token");
        }
        public event WriteLogHandle  WritLog;
        public delegate void WriteLogHandle(string log);

        #endregion

        #region Check
        /// <summary>
        /// view metrics
        /// </summary>
        /// <returns></returns>
        public async Task<QueryCheck> ListChecks()
        {
            return await Get<QueryCheck>("/v1/agent/checks");
        }
        /// <summary>
        /// register check
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> RegisterCheck(RegisterCheck check)
        {
            return await Put(check, $"/v1/agent/check/register");
        }
        /// <summary>
        /// deregister check
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> DeregisterCheck(string  checkID)
        {
            return await Put("", $"/v1/agent/check/deregister/{checkID}");
        }
        /// <summary>
        /// TTL check pass
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckPass(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/v1/agent/check/pass");
        }
        /// <summary>
        /// TTL check warn
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckWarn(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/v1/agent/check/warn");
        }
        /// <summary>
        /// TTL check fail
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckFail(TTLCheckOpt checkPass)
        {
            return await Put(checkPass, $"/v1/agent/check/fail");
        }
        /// <summary>
        /// TTL check update
        /// </summary>
        /// <returns></returns>    
        public async Task<(bool result, string backJson)> TTLCheckUpdate(TTLCheckUpdate checkUpdate)
        {
            return await Put(checkUpdate, $"/v1/agent/check/update");
        }
        #endregion

        #region register and deregister service
        /// <summary>
        /// register service
        /// </summary>
        /// <returns></returns>
        /// <param name="service">service</param>
        public async Task<(bool result, string backJson)> RegisterServices(Service service)
        {
            return await Put(service, $"/v1/agent/service/register");
        }
        /// <summary>
        /// deregister service
        /// </summary>
        /// <returns></returns>
        /// <param name="serviceID">service ID</param>
        public async Task<(bool result, string backJson)> UnRegisterServices(string serviceID)
        {
            return await Put("", $"/v1/agent/service/deregister/{ serviceID}");
            //var client = new HttpClient();
            //client.BaseAddress = new Uri(_baseAddress);
            //var response = await client.PutAsync($"/v1/agent/service/deregister/" + serviceID, null);
            //var backJson = await response.Content.ReadAsStringAsync();
            //return (result: response.StatusCode == System.Net.HttpStatusCode.OK, backJson: backJson);
        }
        #endregion

    }
}
