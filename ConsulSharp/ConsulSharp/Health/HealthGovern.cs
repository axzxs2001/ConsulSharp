using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Health
{
    /// <summary>
    /// Health Govern
    /// </summary>
    public class HealthGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public HealthGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        /// <summary>
        /// This endpoint returns the checks specific to the node provided on the path.
        /// </summary>
        /// <param name="checkNodeParmeter">Check Node Parmeter</param>
        /// <returns></returns>
        public async Task<CheckNodeResult[]> ListChecksForNode(CheckNodeParmeter checkNodeParmeter)
        {          
            return await Get<CheckNodeResult[], CheckNodeParmeter>($"/health/node", checkNodeParmeter);
        }


        /// <summary>
        ///List Checks for Service,This endpoint returns the checks associated with the service provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">Check Service Parmeter</param>
        /// <returns></returns>
        public async Task<CheckNodeResult[]> ListChecksForService(CheckServiceParmeter checkServiceParmeter)
        {          
            return await Get<CheckNodeResult[], CheckServiceParmeter>($"/health/checks", checkServiceParmeter);
        }

        /// <summary>
        ///List Nodes for Service,This endpoint returns the nodes providing the service indicated on the path. Users can also build in support for dynamic load balancing and other features by incorporating the use of health checks.
        /// </summary>
        /// <param name="nodeServiceParmeter">Node Service Parmeter</param>
        /// <returns></returns>
        public async Task<NodeServiceResult[]> ListNodeForService(NodeServiceParmeter nodeServiceParmeter)
        {           
            return await Get<NodeServiceResult[], NodeServiceParmeter>($"/health/service", nodeServiceParmeter);
        }


        /// <summary>
        ///List Checks in State,This endpoint returns the checks in the state provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">Check Service Parmeter</param>
        /// <returns></returns>
        public async Task<BaseCheckNode[]> ListChecksInState(CheckServiceParmeter checkServiceParmeter)
        {        
            return await Get<BaseCheckNode[], CheckServiceParmeter>($"/health/state",checkServiceParmeter);
        }
    }
}
