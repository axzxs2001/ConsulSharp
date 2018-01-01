using AgentCheck=ConsulSharp.Agent.Check;

namespace ConsulSharp.Agent.Service
{
    /// <summary>
    /// Register Service Parmeter
    /// </summary>
    public class RegisterServiceParmeter
    {
        /// <summary>
        /// Specifies a unique ID for this service. This must be unique per agent. This defaults to the Name parameter if not provided.
        /// </summary>
        public string ID
        { get; set; }
        /// <summary>
        /// Specifies the logical name of the service. Many service instances may share the same logical service name.
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// Specifies a list of tags to assign to the service. These tags can be used for later filtering and are exposed via the APIs.
        /// </summary>
        public string[] Tags
        {
            get; set;
        }
        /// <summary>
        /// Specifies the address of the service. If not provided, the agent's address is used as the address for the service during DNS queries.
        /// </summary>
        public string Address
        { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port
        { get; set; }
        /// <summary>
        /// Specifies to disable the anti-entropy feature for this service's tags. If EnableTagOverride is set to true then external agents can update this service in the catalog and modify the tags. Subsequent local sync operations by this agent will ignore the updated tags. For instance, if an external agent modified both the tags and the port for this service and EnableTagOverride was set to true then after the next sync cycle the service's port would revert to the original value but the tags would maintain the updated value. As a counter example, if an external agent modified both the tags and port for this service and EnableTagOverride was set to false then after the next sync cycle the service's port and the tags would revert to the original value and all modifications would be lost.
        /// </summary>
        public bool EnableTagOverride
        { get; set; }
        /// <summary>
        /// Specifies a list of checks. Please see the check documentation for more information about the accepted fields. If you don't provide a name or id for the check then they will be generated. To provide a custom id and/or name set the CheckID and/or Name field. The automatically generated Name and CheckID depend on the position of the check within the array, so even though the behavior is deterministic, it is recommended for all checks to either let consul set the CheckID by leaving the field empty/omitting it or to provide a unique value.
        /// </summary>
        public AgentCheck.Check[] Checks
        { get; set; }
        /// <summary>
        /// Specifies a check. Please see the check documentation for more information about the accepted fields. If you don't provide a name or id for the check then they will be generated. To provide a custom id and/or name set the CheckID and/or Name field.
        /// </summary>
        public AgentCheck.Check Check { get; set; }
    }
}
