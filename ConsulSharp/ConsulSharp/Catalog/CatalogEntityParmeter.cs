

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// Register Entity Parmeter
    /// </summary>
    public class CatalogEntityParmeter
    {
        /// <summary>
        /// An optional UUID to assign to the service. If not provided, one is generated. This must be a 36-character UUID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Specifies the datacenter, which defaults to the agent's datacenter if not provided.
        /// </summary>
        public string Datacenter { get; set; }

        /// <summary>
        /// Specifies the node ID to register.
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Specifies the address to register.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Specifies the tagged addresses.
        /// </summary>
        public TaggedAddress TaggedAddresses { get; set; }
        /// <summary>
        /// Specifies arbitrary KV metadata pairs for filtering purposes.
        /// </summary>
        public object NodeMeta { get; set; }
        /// <summary>
        /// Specifies to register a service. If ID is not provided, it will be defaulted to the value of the Service.Service property. Only one service with a given ID may be present per node. The service Tags, Address, and Port fields are all optional.
        /// </summary>
        public CatalogEntityService Service { get; set; }
        /// <summary>
        /// Specifies to register a check. The register API manipulates the health check entry in the Catalog, but it does not setup the script, TTL, or HTTP check to monitor the node's health. To truly enable a new health check, the check must either be provided in agent configuration or set via the agent endpoint.The CheckID can be omitted and will default to the value of Name. As with Service.ID, the CheckID must be unique on this node. Notes is an opaque field that is meant to hold human-readable text. If a ServiceID is provided that matches the ID of a service on that node, the check is treated as a service level health check, instead of a node level health check. The Status must be one of passing, warning, or critical.The Definition field can be provided with details for a TCP or HTTP health check.For more information, see the Health Checks page.Multiple checks can be provided by replacing Check with Checks and sending an array of Check objects.
        /// </summary>
        public ConsulSharp.Catalog.Check Check { get; set; }
        /// <summary>
        /// Specifies whether to skip updating the node part of the registration. Useful in the case where only a health check or service entry on a node needs to be updated.
        /// </summary>
        public bool SkipNodeUpdate { get; set; }
    }
}
