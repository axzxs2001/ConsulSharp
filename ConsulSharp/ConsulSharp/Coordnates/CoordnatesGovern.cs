using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Coordinates
{
    /// <summary>
    /// Coordnates Govern
    /// </summary>
    public class CoordnatesGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public CoordnatesGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint returns the WAN network coordinates for all Consul servers, organized by datacenters. It serves data out of the server's local Serf data, so its results may vary as requests are handled by different servers in the cluster.
        /// </summary>
        /// <returns></returns>
        public async Task<WANCoordinatesResult[]> ReadWANCoordinates()
        {
            return await Get<WANCoordinatesResult[]>($"/coordinate/datacenters");
        }
        /// <summary>
        /// This endpoint returns the LAN network coordinates for all nodes in a given datacenter.
        /// </summary>
        /// <param name="lanCoordinates">LAN Coordinates Parmeter</param>
        /// <returns></returns>
        public async Task<LanCoordinateResult[]> ReadLANCoordinatesForAllNodes(LANCoordinatesParmeter  lANCoordinatesParmeter)
        {
            return await Get<LanCoordinateResult[], LANCoordinatesParmeter>($"/coordinate/nodes", lANCoordinatesParmeter);
        }
        /// <summary>
        /// This endpoint returns the LAN network coordinates for the given node.
        /// </summary>
        /// <param name="lANCoordinatesParmeter">LAN Coordinates Parmeter</param>
        /// <returns></returns>
        public async Task<LanCoordinateResult[]> ReadLANCoordinatesForANodes(LANCoordinatesParmeter lANCoordinatesParmeter)
        {
            return await Get<LanCoordinateResult[], LANCoordinatesParmeter>($"/coordinate/node", lANCoordinatesParmeter);
        }

        /// <summary>
        /// This endpoint updates the LAN network coordinates for a node in a given datacenter.
        /// </summary>
        /// <returns></returns>
        /// <param name="dc">datacenter</param>
        public async Task<(bool result, LANCoordinatesParmeter lanCoordinates)> UpdateLANCoordinatesForANode(string dc)
        {
            return await Put<string, LANCoordinatesParmeter>(dc, $"/coordinate/update");           
        }
    }
}
