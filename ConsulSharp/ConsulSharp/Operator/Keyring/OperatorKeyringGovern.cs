
using System.Threading.Tasks;
namespace ConsulSharp.Operator.Keyring
{
    /// <summary>
    /// Operator Keyring Govern
    /// </summary>
    public class OperatorKeyringGovern : Govern
    {

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public OperatorKeyringGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }  

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
        public async Task<(bool result, ListGossipEncryptionKeysResult[] listGossipEncryptionKeysResults)> AddNewGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter  addNewGossipEncryptionKeyParmeter)
        {
            return await Post<AddNewGossipEncryptionKeyParmeter, ListGossipEncryptionKeysResult[]>(addNewGossipEncryptionKeyParmeter, "/operator/keyring");
        }

        /// <summary>
        /// This endpoint changes the primary gossip encryption key. The key must already be installed before this operation can succeed.
        /// </summary>
        /// <param name="addNewGossipEncryptionKeyParmeter">Add New Gossip Encryption Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> ChangePrimaryGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter addNewGossipEncryptionKeyParmeter)
        {
            return await Put<AddNewGossipEncryptionKeyParmeter, string>(addNewGossipEncryptionKeyParmeter, "/operator/keyring");
        }
        /// <summary>
        /// This endpoint removes a gossip encryption key from the cluster. This operation may only be performed on keys which are not currently the primary key.
        /// </summary>
        /// <param name="addNewGossipEncryptionKeyParmeter">Add New Gossip Encryption Key Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> DeleteGossipEncryptionKey(AddNewGossipEncryptionKeyParmeter addNewGossipEncryptionKeyParmeter)
        {
            return await Delete<AddNewGossipEncryptionKeyParmeter, string>(addNewGossipEncryptionKeyParmeter, "/operator/keyring");
        }
        #endregion
    }
}
