using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Update Configuration Parmeter
    /// </summary>
    public class UpdateConfigurationParmeter
    {
        /// <summary>
        ///  Specifies the datacenter to query.This will default to the datacenter of the agent being queried.This is specified as part of the URL as a query string.
        /// </summary>
        public string DC { get; set; }

        /// <summary>
        /// Specifies to use a Check-And-Set operation.The update will only happen if the given index matches the ModifyIndex of the configuration at the time of writing.

        /// </summary>
        public int Cas { get; set; }

        /// <summary>
        /// Specifies automatic removal of dead server nodes periodically and whenever a new server is added to the cluster.
        /// </summary>
        public bool CleanupDeadServers { get; set; }
        /// <summary>
        /// Specifies the maximum amount of time a server can go without contact from the leader before being considered unhealthy.Must be a duration value such as 10s.
        /// </summary>
        public string LastContactThreshold { get; set; }
        /// <summary>
        /// specifies the maximum number of log entries that a server can trail the leader by before being considered unhealthy.
        /// </summary>
        public int MaxTrailingLogs { get; set; }
        /// <summary>
        ///  Specifies the minimum amount of time a server must be stable in the 'healthy' state before being added to the cluster.Only takes effect if all servers are running Raft protocol version 3 or higher.Must be a duration value such as 30s.
        /// </summary>
        public string ServerStabilizationTime { get; set; }

        /// <summary>
        ///  Controls the node-meta key to use when Autopilot is separating servers into zones for redundancy.Only one server in each zone can be a voting member at one time.If left blank, this feature will be disabled.
        /// </summary>
        public string RedundancyZoneTag { get; set; }

        /// <summary>
        ///  Disables Autopilot's upgrade migration strategy in Consul Enterprise of waiting until enough newer-versioned servers have been added to the cluster before promoting any of them to voters.
        /// </summary>
        public bool DisableUpgradeMigration { get; set; }
        /// <summary>
        ///  Controls the node-meta key to use for version info when performing upgrade migrations.If left blank, the Consul version will be used.
        /// </summary>
        public string UpgradeVersionTag { get; set; }
    }
}
