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
    public class CatalogGovern: Govern
    {
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public CatalogGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }     

        #region catalog
        /// <summary>
        /// register service
        /// </summary>
        /// <returns></returns>
        /// <param name="service">service</param>
        public async Task<(bool result, string backJson)> RegisterCatalog(CatalogEntity catalog)
        {
            return await Put(catalog, $"/v1/catalog/register");
        }
        /// <summary>
        /// deregister service
        /// </summary>
        /// <returns></returns>
        /// <param name="deregisterEntity">deregister entity</param>
        public async Task<(bool result, string backJson)> DeregisterCatalog(DeCatalogEntity deregisterEntity)
        {
            return await Put(deregisterEntity, $"/v1/catalog/deregister");
        }

        /// <summary>
        /// get catalog datacenter
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> CatalogDatacenters()
        {
            var json = await Get("/v1/catalog/datacenters");
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    var services = new List<string>();
                    foreach (var serviceCheck in jsonObj)
                    {
                        services.Add(serviceCheck.Value);
                    }
                    return services.ToArray();
                }
                catch (JsonReaderException)
                {
                    throw new ApplicationException($"back content is error formatter:{json}");
                }
            }
            else
            {
                throw new ApplicationException($"back content is empty.");
            }
        }
        /// <summary>
        /// get catalog nodes
        /// </summary>
        /// <returns></returns>
        public async Task<HealthCatalogNode[]> CatalogNodes()
        {
            return await Get<HealthCatalogNode[]>("/v1/catalog/nodes");
        }
        /// <summary>
        /// get catalog node by name
        /// </summary>
        /// <returns></returns>
        public async Task<CatalogNode> CatalogNodeByName(string nodeName)
        {
            return await Get<CatalogNode>($"/v1/catalog/node/{nodeName}");
        }
        /// <summary>
        /// get catalog services
        /// </summary>    
        /// <param name="requestUrl">Request Url</param>
        /// <param name="dataCenter">Data Center Name</param>
        /// <returns></returns>
        public async Task<Dictionary<string, string[]>> CatalogServices(string dataCenter = null)
        {

            var json = await Get("/v1/catalog/services", dataCenter);
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    dynamic jsonObj = JsonConvert.DeserializeObject(json);
                    var services = new Dictionary<string, string[]>();
                    foreach (var serviceCheck in jsonObj)
                    {
                        var names = new List<string>();
                        foreach (var child in serviceCheck.Value)
                        {
                            names.Add(child.Value);
                        }
                        services.Add(serviceCheck.Name, names.ToArray());
                    }
                    return services;
                }
                catch (JsonReaderException)
                {
                    throw new ApplicationException($"back content is error formatter:{json}");
                }
            }
            else
            {
                throw new ApplicationException($"back content is empty.");
            }
        }

        /// <summary>
        /// get catalog service by service name
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="dataCenter">Data Center Name</param> 
        /// <returns></returns>
        public async Task<CatalogService[]> CatalogServiceByName(string serviceName, string dataCenter = null)
        {
            return await Get<CatalogService[]>($"/v1/catalog/service/{serviceName}", dataCenter);
        }
        #endregion   

     

    }
}
