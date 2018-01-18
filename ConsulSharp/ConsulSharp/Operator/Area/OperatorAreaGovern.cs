using System.Threading.Tasks;

namespace ConsulSharp.Operator.Area
{
    /// <summary>
    /// Operator Area Govern
    /// </summary>
    public class OperatorAreaGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorAreaGovern(string baseAddress = "http://127.0.0.1:8500") : base(baseAddress)
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
            return await Post<CreateNetworkAreaParmeter, CreateNetworkAreaResult>(createNetworkAreaParmeter, $"/operator/area");
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
        public async Task<ListNetworkAreasResult[]> ListSpecificNetworkArea(NetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Get<ListNetworkAreasResult[], NetworkAreaParmeter>("/operator/area", listSpecificNetworkAreaParmeter);
        }

        /// <summary>
        /// This endpoint deletes a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">Delete Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backString)> DeleteNetworkArea(NetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Delete<NetworkAreaParmeter, string>(listSpecificNetworkAreaParmeter, "/operator/area");
        }


        /// <summary>
        /// This endpoint attempts to join the given Consul servers into a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">List Specific Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, JoinNetworkAreaResult[] joinNetworkAreaResults)> JoinNetworkArea(NetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Put<NetworkAreaParmeter, JoinNetworkAreaResult[]>(listSpecificNetworkAreaParmeter, "	/operator/area/join");
        }

        /// <summary>
        /// This endpoint provides a listing of the Consul servers present in a specific network area.
        /// </summary>
        /// <param name="listSpecificNetworkAreaParmeter">List Specific Network Area Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, ListNetworkAreaMembersResult[] listNetworkAreaMembersResults)> ListNetworkAreaMembers(NetworkAreaParmeter listSpecificNetworkAreaParmeter)
        {
            return await Put<NetworkAreaParmeter, ListNetworkAreaMembersResult[]>(listSpecificNetworkAreaParmeter, "/operator/area/members");
        }
        #endregion
    }
}
