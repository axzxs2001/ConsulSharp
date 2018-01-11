using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Snapshot
{
    /// <summary>
    /// Snapshot Govern
    /// </summary>
    public class SnapshotGovern : Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public SnapshotGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }

        /// <summary>
        /// This endpoint generates and returns an atomic, point-in-time snapshot of the Consul server state. Snapshots are exposed as gzipped tar archives which internally contain the Raft metadata required to restore, as well as a binary serialized version of the Consul server state.The contents are covered internally by SHA-256 hashes.These hashes are verified during snapshot restore operations.The structure of the archive is internal to Consul and not intended to be used other than for restore operations.The archives are not designed to be modified before a restore.
        /// </summary>
        /// <param name="generateSnapshotParmeter"></param>
        /// <returns></returns>
        public async Task GenerateSnapshot(GenerateSnapshotParmeter generateSnapshotParmeter)
        {
             await Get<string,GenerateSnapshotParmeter>($"/kv", generateSnapshotParmeter);
        }

        /// <summary>
        /// The body of the request should be a snapshot archive returned from a previous call to the GET method.
        /// </summary>
        /// <param name="restoreSnapshotParmeter">Restore Snapshot Result</param>
        /// <returns></returns>
        public async Task<(bool result, string restoreSnapshotResult)>
RestoreSnapshot(RestoreSnapshotParmeter   restoreSnapshotParmeter)
        {
            return await Put<RestoreSnapshotParmeter, string>(restoreSnapshotParmeter, $"/snapshot");
        }
    }
}
