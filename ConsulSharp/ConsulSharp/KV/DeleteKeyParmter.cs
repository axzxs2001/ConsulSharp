using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.KV
{
    /// <summary>
    /// Delete Key Parmter
    /// </summary>
    public class DeleteKeyParmeter
    {
        /// <summary>
        /// Specifies to delete all keys which have the specified prefix. Without this, only a key with an exact match will be deleted.
        /// </summary>
        public bool Recurse { get; set; }

        /// <summary>
        /// Specifies to use a Check-And-Set operation. This is very useful as a building block for more complex synchronization primitives. Unlike PUT, the index must be greater than 0 for Consul to take any action: a 0 index will not delete the key. If the index is non-zero, the key is only deleted if the index matches the ModifyIndex of that key.
        /// </summary>
        public int Cas { get; set; }

    }
}
