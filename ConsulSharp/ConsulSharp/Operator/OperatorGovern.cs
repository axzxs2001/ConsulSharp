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
        /// <param name="createNetworkAreaParmeter"></param>
        /// <returns></returns>
        public async Task<CreateNetworkAreaResult> CreateNetworkArea(CreateNetworkAreaParmeter createNetworkAreaParmeter)
        {
            return await Get<CreateNetworkAreaResult, CreateNetworkAreaParmeter>("/operator/area", createNetworkAreaParmeter);
        }
    }
}
