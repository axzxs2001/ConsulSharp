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

        #region Area
        /// <summary>
        /// This endpoint creates a new network area and returns its ID if it is created successfully.
        /// </summary>
        /// <param name="createNetworkAreaParmeter">Create Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, CreateNetworkAreaResult createNetworkAreaResult)> CreateNetworkArea(CreateNetworkAreaParmeter createNetworkAreaParmeter)
        {
            return await Post<CreateNetworkAreaParmeter, CreateNetworkAreaResult>(createNetworkAreaParmeter, "/operator/area");
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
        public async Task<(bool result, string backString)> UpdateNetworkArea(UpdateNetworkAreaParmeter updateNetworkAreaParmeter)
        {
            return await Put<UpdateNetworkAreaParmeter>(updateNetworkAreaParmeter, "/operator/area");
        }

        /// <summary>
        /// This endpoint lists a specific network area.
        /// </summary>
        /// <param name="List Specific Network Area Parmeter">ListSpecificNetworkAreaParmeter</param>
        /// <returns></returns>
        public async Task<ListNetworkAreasResult[]> ListSpecificNetworkArea(ListSpecificNetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Get<ListNetworkAreasResult[], ListSpecificNetworkAreaParmeter>("/operator/area", listSpecificNetworkAreaParmeter);
        }

        /// <summary>
        /// This endpoint deletes a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">Delete Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backString)> DeleteNetworkArea(ListSpecificNetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Delete<ListSpecificNetworkAreaParmeter, string>(listSpecificNetworkAreaParmeter, "/operator/area");
        }


        /// <summary>
        /// This endpoint attempts to join the given Consul servers into a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">List Specific Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, JoinNetworkAreaResult[] joinNetworkAreaResults)> JoinNetworkArea(ListSpecificNetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Put<ListSpecificNetworkAreaParmeter, JoinNetworkAreaResult[]>(listSpecificNetworkAreaParmeter, "	/operator/area/join");
        }

        /// <summary>
        /// This endpoint provides a listing of the Consul servers present in a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">List Specific Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, ListNetworkAreaMembersResult[] listNetworkAreaMembersResults)> ListNetworkAreaMembers(ListSpecificNetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Put<ListSpecificNetworkAreaParmeter, ListNetworkAreaMembersResult[]>(listSpecificNetworkAreaParmeter, "/operator/area/members");
        }
        #endregion


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
        public async Task<(bool result, ConsulSharp.Operator.Autopilot.ReadConfigurationResult readConfigurationResult)> UpdateConfiguration(UpdateConfigurationParmeter updateConfigurationParmeter)
        {
            return await Put<UpdateConfigurationParmeter, ConsulSharp.Operator.Autopilot.ReadConfigurationResult>(updateConfigurationParmeter, "	/operator/autopilot/configuration");
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

        #region Keyring
        /// <summary>
        /// This endpoint lists the gossip encryption keys installed on both the WAN and LAN rings of every known datacenter.If ACLs are enabled, the client will need to supply an ACL Token with keyring read privileges.
        /// </summary>
        /// <param name="listGossipEncryptionKeysParmeter">List Gossip Encryption Keys Parmeter</param>
        /// <returns></returns>
        public async Task<ListGossipEncryptionKeysResult[]> ListGossipEncryptionKeys(ListGossipEncryptionKeysParmeter listGossipEncryptionKeysParmeter)
        {
            return await Get<ListGossipEncryptionKeysResult[], ListGossipEncryptionKeysParmeter>("/operator/keyring", listGossipEncryptionKeysParmeter);
        }
        /// <summary>
        /// This endpoint installs a new gossip encryption key into the cluster.
        /// </summary>
        /// <param name="addNewGossipEncryptionKeyParmeter">Add New Gossip Encryption Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> AddNewGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter  addNewGossipEncryptionKeyParmeter)
        {
            return await Post<AddNewGossipEncryptionKeyParmeter, string>(addNewGossipEncryptionKeyParmeter, "	/operator/keyring");
        }

        /// <summary>
        /// This endpoint changes the primary gossip encryption key. The key must already be installed before this operation can succeed.
        /// </summary>
        /// <param name="addNewGossipEncryptionKeyParmeter">Add New Gossip Encryption Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> ChangePrimaryGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter addNewGossipEncryptionKeyParmeter)
        {
            return await Put<AddNewGossipEncryptionKeyParmeter, string>(addNewGossipEncryptionKeyParmeter, "	/operator/keyring");
        }
        /// <summary>
        /// This endpoint removes a gossip encryption key from the cluster. This operation may only be performed on keys which are not currently the primary key.
        /// </summary>
        /// <param name="addNewGossipEncryptionKeyParmeter">Add New Gossip Encryption Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> DeleteGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter addNewGossipEncryptionKeyParmeter)
        {
            return await Delete<AddNewGossipEncryptionKeyParmeter, string>(addNewGossipEncryptionKeyParmeter, "	/operator/keyring");
        }
        #endregion
    }
}
