using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsulSharp.Operator.Area;

namespace ConsulSharp.Operator
{
    /// <summary>
    /// Operator Govern
    /// </summary>
    public class OperatorGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint creates a new network area and returns its ID if it is created successfully.
        /// </summary>
        /// <param name="createNetworkAreaParmeter">Create Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result,CreateNetworkAreaResult createNetworkAreaResult)> CreateNetworkArea(CreateNetworkAreaParmeter createNetworkAreaParmeter)
        {
            return await Post<CreateNetworkAreaParmeter, CreateNetworkAreaResult>(createNetworkAreaParmeter,"/operator/area");
        }
        /// <summary>
        /// his endpoint lists all network areas.
        /// </summary>
        /// <param name="createNetworkAreaParmeter">List Network Areas Parmeter</param>
        /// <returns></returns>
        public async Task<ListNetworkAreasResult[]> ListNetworkAreas(ListNetworkAreasParmeter listNetworkAreasParmeter)
        {
            return await Get<ListNetworkAreasResult[], ListNetworkAreasParmeter>("/operator/area", listNetworkAreasParmeter);
        }
        /// <summary>
        /// This endpoint updates a network area to the given configuration.
        /// </summary>
        /// <param name="updateNetworkAreaParmeter">Update Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backString)> UpdateNetworkArea(UpdateNetworkAreaParmeter  updateNetworkAreaParmeter)
        {
            return await Post<UpdateNetworkAreaParmeter>(updateNetworkAreaParmeter, "/operator/area");
        }

    }
}
