using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConsulSharp.Operator.Area;
using ConsulSharp.Operator.Autopilot;
using ConsulSharp.Operator.Keyring;
namespace ConsulSharp.Operator.Segments
{
    /// <summary>
    /// Operator Segments Govern
    /// </summary>
    public class OperatorSegmentsGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorSegmentsGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint lists all network areas.
        /// </summary>
        /// <param name="listNetworkSegmentsParmeter">List Network Segments Parmeter</param>
        /// <returns></returns>
        public async Task<string[]> ListNetworkSegments(ListNetworkSegmentsParmeter  listNetworkSegmentsParmeter)
        {
            return await Get<string[], ListNetworkSegmentsParmeter>("/operator/raft/configuration", listNetworkSegmentsParmeter);
        }
      
    }
}
