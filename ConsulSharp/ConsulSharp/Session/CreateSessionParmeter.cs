using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Session
{
    /// <summary>
    /// Create Session Parmeter
    /// </summary>
    public class CreateSessionParmeter
    {
        /// <summary>
        ///  Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter. Using this across datacenters is not recommended.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifies the duration for the lock delay.
        /// </summary>
        public string LockDelay { get; set; }
        /// <summary>
        /// Specifies the name of the node.This must refer to a node that is already registered.
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// Specifies a human-readable name for the session.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// specifies a list of associated health checks.It is highly recommended that, if you override this list, you include the default serfHealth.
        /// </summary>
        public string[] Checks { get; set; }
        /// <summary>
        /// Controls the behavior to take when a session is invalidated. Valid values are:
        ///    release - causes any locks that are held to be released
        ///    delete - causes any locks that are held to be deleted
        /// </summary>
        public string Behavior { get; set; }
        /// <summary>
        /// Specifies the number of seconds(between 10s and 86400s). If provided, the session is invalidated if it is not renewed before the TTL expires.The lowest practical TTL should be used to keep the number of managed sessions low. When locks are forcibly expired, such as during a leader election, sessions may not be reaped for up to double this TTL, so long TTL values (> 1 hour) should be avoided.
        /// </summary>
        public string TTL { get; set; }

    }
}
