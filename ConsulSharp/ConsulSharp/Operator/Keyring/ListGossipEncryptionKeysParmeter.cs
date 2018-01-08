using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Keyring
{

    /// <summary>
    /// List Gossip Encryption Keys Parmeter
    /// </summary>
    public class ListGossipEncryptionKeysParmeter
    {
        /// <summary>
        /// Specifies the relay factor. Setting this to a non-zero value will cause nodes to relay their responses through this many randomly-chosen other nodes in the cluster. The maximum allowed value is 5. This is specified as part of the URL as a query parameter.
        /// </summary>
        [FieldName("relay-factor")]
        public int RelayFactor { get; set; }
    }
}
