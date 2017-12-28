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
        /// Read WAN Coordinates
        /// </summary>
        /// <returns></returns>
        public async Task<WANCoordinates[]> ReadWANCoordinates()
        {
            return await Get<WANCoordinates[]>($"/coordinate/datacenters");
        }
        /// <summary>
        /// Read LAN Coordinates for all nodes
        /// </summary>
        /// <param name="lanCoordinates">LAN Coordinates</param>
        /// <returns></returns>
        public async Task<LanCoordinate[]> ReadLANCoordinatesForAllNodes(LANCoordinatesParmeter lanCoordinates)
        {
            return await Get<LanCoordinate[]>($"/coordinate/nodes/{(string.IsNullOrEmpty(lanCoordinates.DC) ? lanCoordinates.Segment : lanCoordinates.DC)}");
        }
        /// <summary>
        /// Read LAN Coordinates for a node
        /// </summary>
        /// <param name="lanCoordinates">LAN Coordinates</param>
        /// <returns></returns>
        public async Task<LanCoordinate[]> ReadLANCoordinatesForANodes(LANCoordinatesParmeter lanCoordinates)
        {
            return await Get<LanCoordinate[]>($"/coordinate/node/{(string.IsNullOrEmpty(lanCoordinates.DC) ? lanCoordinates.Segment : lanCoordinates.DC)}");
        }

        /// <summary>
        /// Update LAN Coordinates for a node
        /// </summary>
        /// <returns></returns>
        /// <param name="dc">datacenter</param>
        public async Task<(bool result, LANCoordinatesParmeter lanCoordinates)> UpdateLANCoordinatesForANode(string dc)
        {
            return await Put<string, LANCoordinatesParmeter>(dc, $"/coordinate/update");           
        }
    }
}
