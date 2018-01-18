using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

using System.Threading.Tasks;
namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Operator Autopilot Govern
    /// </summary>
    public class OperatorAutopilotGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorAutopilotGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        #region Autopilot
        /// <summary>
        /// This endpoint retrieves its latest Autopilot configuration.
        /// </summary>
        /// <param name="readConfigurationParmeter">Read Configuration Result</param>
        /// <returns></returns>
        public async Task<ConsulSharp.Operator.Autopilot.ReadConfigurationResult> ReadConfiguration(ReadConfigurationParmeter readConfigurationParmeter)
        {
            return await Get<ConsulSharp.Operator.Autopilot.ReadConfigurationResult, ReadConfigurationParmeter>("/operator/autopilot/configuration", readConfigurationParmeter);
        }

        /// <summary>
        /// This endpoint updates the Autopilot configuration of the cluster.
        /// </summary>
        /// <param name="updateConfigurationParmeter">Update Configuration Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string jsonContent)> UpdateConfiguration(UpdateConfigurationParmeter updateConfigurationParmeter)
        {
            return await Put<UpdateConfigurationParmeter,string>(updateConfigurationParmeter, "/operator/autopilot/configuration");
        }
        /// <summary>
        /// This endpoint queries the health of the autopilot status.
        /// </summary>
        /// <param name="readHealthParmeter">Read Health Parmeter</param>
        /// <returns></returns>
        public async Task<ReadHealthResult> ReadHealth(ReadHealthParmeter readHealthParmeter)
        {
            return await Get<ReadHealthResult, ReadHealthParmeter>("/operator/autopilot/health", readHealthParmeter);
        }


        #endregion

     
    }
}
