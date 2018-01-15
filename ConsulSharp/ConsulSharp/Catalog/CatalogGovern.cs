using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// Service Govern
    /// </summary>
    public class CatalogGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public CatalogGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }

        #region catalog
        /// <summary>
        /// This endpoint is a low-level mechanism for registering or updating entries in the catalog. It is usually preferable to instead use the agent endpoints for registration as they are simpler and perform anti-entropy.
        /// </summary>
        /// <returns></returns>
        /// <param name="catalogEntityParmeter">Catalog Entity Parmeter</param>
        public async Task<(bool result, string backJson)> RegisterEntity(RegisterEntityParmeter catalogEntityParmeter)
        {
            return await Put(catalogEntityParmeter, $"/catalog/register");
        }
        /// <summary>
        /// This endpoint is a low-level mechanism for directly removing entries from the Catalog. It is usually preferable to instead use the agent endpoints for deregistration as they are simpler and perform anti-entropy.
        /// </summary>
        /// <returns></returns>
        /// <param name="deregisterEntityParmeter">Deregister Entity Parmeter</param>
        public async Task<(bool result, string backJson)> DeregisterCatalog(DeregisterEntityParmeter deregisterEntityParmeter)
        {
            return await Put(deregisterEntityParmeter, $"/catalog/deregister");
        }

        /// <summary>
        /// This endpoint returns the list of all known datacenters. The datacenters will be sorted in ascending order based on the estimated median round trip time from the server to the servers in that datacenter.        This endpoint does not require a cluster leader and will succeed even during an availability outage.Therefore, it can be used as a simple check to see if any Consul servers are routable.
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> ListDatacenters()
        {
            return await Get<string[]>("/catalog/datacenters");
        }
        /// <summary>
        /// This endpoint and returns the nodes registered in a given datacenter.
        /// </summary>
        /// <returns></returns>
        /// <param name="listNodesParmeter">List Nodes Parmeter</param>
        public async Task<ListNodesResult[]> ListNodes(ListNodesParmeter listNodesParmeter)
        {
            return await Get<ListNodesResult[], ListNodesParmeter>("/catalog/nodes", listNodesParmeter);
        }

        /// <summary>
        /// This endpoint returns the node's registered services.
        /// </summary>
        /// <param name="listServicesForNodeParmeter">List Services For Node Parmeter</param>
        /// <returns></returns>
        public async Task<ListServicesForNodeResult> ListServicesForNode(ListServicesForNodeParmeter listServicesForNodeParmeter)
        {
            return await Get<ListServicesForNodeResult, ListServicesForNodeParmeter>($"/catalog/node", listServicesForNodeParmeter);
        }
        /// <summary>
        /// This endpoint returns the services registered in a given datacenter.
        /// </summary>
        /// <param name="listServicesParmeter">List Services Parmeter</param>
        /// <returns></returns>

        public async Task<Dictionary<string, dynamic>> ListServices(ListServicesParmeter listServicesParmeter)
        {
            return await Get<Dictionary<string, dynamic>, ListServicesParmeter>("/catalog/services", listServicesParmeter);
        }


        /// <summary>
        /// This endpoint returns the nodes providing a service in a given datacenter.
        /// </summary>    
        /// <param name="listNodesForServiceParmeter">List Nodes For Service Parmeter</param>
        /// <returns></returns>
        public async Task<ListNodesForServiceResult[]> ListNodesForService(ListNodesForServiceParmeter  listNodesForServiceParmeter)
        {

            return await Get<ListNodesForServiceResult[], ListNodesForServiceParmeter>($"/catalog/service/{listNodesForServiceParmeter.Service}", listNodesForServiceParmeter);

        }

    
        #endregion



    }
}
