using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Operator.Autopilot
{
    /// <summary>
    /// Read Configuration Result
    /// </summary>
    public class ReadConfigurationResult
    {
        /// <summary>
        /// CleanupDeadServers
        /// </summary>
        public bool CleanupDeadServers { get; set; }
        /// <summary>
        /// LastContactThreshold
        /// </summary>
        public string LastContactThreshold { get; set; }
        /// <summary>
        /// MaxTrailingLogs
        /// </summary>
        public int MaxTrailingLogs { get; set; }
        /// <summary>
        /// ServerStabilizationTime
        /// </summary>
        public string ServerStabilizationTime { get; set; }
        /// <summary>
        /// RedundancyZoneTag
        /// </summary>
        public string RedundancyZoneTag { get; set; }
        /// <summary>
        /// DisableUpgradeMigration
        /// </summary>
        public bool DisableUpgradeMigration { get; set; }
        /// <summary>
        /// UpgradeVersionTag
        /// </summary>
        public string UpgradeVersionTag { get; set; }
        /// <summary>
        /// CreateIndex
        /// </summary>
        public int CreateIndex { get; set; }
        /// <summary>
        /// ModifyIndex
        /// </summary>
        public int ModifyIndex { get; set; }
    }
}
