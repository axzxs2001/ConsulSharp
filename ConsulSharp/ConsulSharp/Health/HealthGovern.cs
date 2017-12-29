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
        /// List Checks for Node,This endpoint returns the checks specific to the node provided on the path.
        /// </summary>
        /// <param name="checkNodeParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<CheckNode[]> ListChecksForNode(CheckNodeParmeter checkNodeParmeter)
        {
            var parmeter = new StringBuilder();
            if (!string.IsNullOrEmpty(checkNodeParmeter.DC))
            {
                parmeter.Append($"&dc={checkNodeParmeter.DC}");
            }
            if (!string.IsNullOrEmpty(checkNodeParmeter.Node))
            {
                parmeter.Append($"&node={checkNodeParmeter.Node}");
            }
            return await Get<CheckNode[]>($"/health/node/?{parmeter.ToString().TrimStart('&')}");
        }


        /// <summary>
        ///List Checks for Service,This endpoint returns the checks associated with the service provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<CheckNode[]> ListChecksForService(CheckServiceParmeter checkServiceParmeter)
        {
            var parmeter = new StringBuilder();
            if (!string.IsNullOrEmpty(checkServiceParmeter.DC))
            {
                parmeter.Append($"&dc={checkServiceParmeter.DC}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Service))
            {
                parmeter.Append($"&service={checkServiceParmeter.Service}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Near))
            {
                parmeter.Append($"&near={checkServiceParmeter.Near}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Node_Meta))
            {
                parmeter.Append($"&node-meta={checkServiceParmeter.Node_Meta}");
            }
            return await Get<CheckNode[]>($"/health/checks/?{parmeter.ToString().TrimStart('&')}");
        }

        /// <summary>
        ///List Nodes for Service,This endpoint returns the nodes providing the service indicated on the path. Users can also build in support for dynamic load balancing and other features by incorporating the use of health checks.
        /// </summary>
        /// <param name="nodeServiceParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<NodeService[]> ListNodeForService(NodeServiceParmeter nodeServiceParmeter)
        {
            var parmeter = new StringBuilder();
            if (!string.IsNullOrEmpty(nodeServiceParmeter.DC))
            {
                parmeter.Append($"&dc={nodeServiceParmeter.DC}");
            }
            if (!string.IsNullOrEmpty(nodeServiceParmeter.Service))
            {
                parmeter.Append($"&service={nodeServiceParmeter.Service}");
            }
            if (!string.IsNullOrEmpty(nodeServiceParmeter.Near))
            {
                parmeter.Append($"&near={nodeServiceParmeter.Near}");
            }
            if (!string.IsNullOrEmpty(nodeServiceParmeter.Node_Meta))
            {
                parmeter.Append($"&node-meta={nodeServiceParmeter.Node_Meta}");
            }
            if (!string.IsNullOrEmpty(nodeServiceParmeter.Tag))
            {
                parmeter.Append($"&tag={nodeServiceParmeter.Tag}");
            }           
            parmeter.Append($"&node-meta={nodeServiceParmeter.passing}");            
            return await Get<NodeService[]>($"/health/service/?{parmeter.ToString().TrimStart('&')}");
        }


        /// <summary>
        ///List Checks in State,This endpoint returns the checks in the state provided on the path.
        /// </summary>
        /// <param name="checkServiceParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<BaseCheckNode[]> ListChecksInState(CheckServiceParmeter checkServiceParmeter)
        {
            var parmeter = new StringBuilder();
            if (!string.IsNullOrEmpty(checkServiceParmeter.DC))
            {
                parmeter.Append($"&dc={checkServiceParmeter.DC}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Service))
            {
                parmeter.Append($"&service={checkServiceParmeter.Service}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Near))
            {
                parmeter.Append($"&near={checkServiceParmeter.Near}");
            }
            if (!string.IsNullOrEmpty(checkServiceParmeter.Node_Meta))
            {
                parmeter.Append($"&node-meta={checkServiceParmeter.Node_Meta}");
            }         
            return await Get<BaseCheckNode[]>($"/health/state/?{parmeter.ToString().TrimStart('&')}");
        }
    }
}
