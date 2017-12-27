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
    public class HealthGovern: Govern
    {
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public HealthGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        } 
        #region health

        /// <summary>
        /// get health services by service name
        /// </summary>
        /// <param name="serviceName">Service Name</param>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="dataCenter">Data Center Name</param>
        /// <param name="serviceState">service state(enable or disable)</param>
        /// <returns></returns>
        public async Task<QueryHealthService[]> HealthServiceByName(string serviceName, string dataCenter = null)
        {
            return await Get<QueryHealthService[]>($"/v1/health/service/{serviceName}", dataCenter);
        }

        #endregion


    }
}
