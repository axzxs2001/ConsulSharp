using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.KV
{
    /// <summary>
    /// Create Update Key Parmeter
    /// </summary>
    public class CreateUpdateKeyParmeter
    {
        /// <summary>
        /// Specifies the path of the key to read.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifies an unsigned value between 0 and (2^64)-1. Clients can choose to use this however makes sense for their application. This is specified as part of the URL as a query parameter.
        /// </summary>
        public int Flags { get; set; }
        /// <summary>
        /// Specifies to use a Check-And-Set operation. This is very useful as a building block for more complex synchronization primitives. If the index is 0, Consul will only put the key if it does not already exist. If the index is non-zero, the key is only set if the index matches the ModifyIndex of that key.
        /// </summary>
        public int Cas { get; set; }
        /// <summary>
        /// Specifies to use a lock acquisition operation. This is useful as it allows leader election to be built on top of Consul. If the lock is not held and the session is valid, this increments the LockIndex and sets the Session value of the key in addition to updating the key contents. A key does not need to exist to be acquired. If the lock is already held by the given session, then the LockIndex is not incremented but the key contents are updated. This lets the current lock holder update the key contents without having to give up the lock and reacquire it.
        /// </summary>
        public string Acquire{ get; set; }
        /// <summary>
        /// Specifies to use a lock release operation. This is useful when paired with ?acquire= as it allows clients to yield a lock. This will leave the LockIndex unmodified but will clear the associated Session of the key. The key must be held by this session to be unlocked.
        public string Release { get; set; }
    }
}
