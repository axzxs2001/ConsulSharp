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
    public class AgentGovern: Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public AgentGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }

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
            return await Get<Metrics>("/v1/metrics");
        }


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
