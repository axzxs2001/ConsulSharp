using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Agent.Check
{
    /// <summary>
    /// register Check
    /// </summary>
    public class RegisterCheckParmeter
    {
        /// <summary>
        /// Specifies a unique ID for this check on the node. This defaults to the "Name" parameter, but it may be necessary to provide an ID for uniqueness.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Specifies the name of the check.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the frequency at which to run this check. This is required for HTTP and TCP checks.
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// Specifies arbitrary information for humans. This is not used by Consul internally.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        ///  Specifies that checks associated with a service should deregister after this time. This is specified as a time duration with suffix like "10m". If a check is in the critical state for more than this configured value, then its associated service (and all of its associated checks) will automatically be deregistered. The minimum timeout is 1 minute, and the process that reaps critical services runs every 30 seconds, so it may take slightly longer than the configured timeout to trigger the deregistration. This should generally be configured with a timeout that's much, much longer than any expected recoverable outage for the given service.
        /// </summary>
        public string DeregisterCriticalServiceAfter { get; set; }
        /// <summary>
        /// Specifies command arguments to run to update the status of the check. Prior to Consul 1.0, checks used a single Script field to define the command to run, and would always run in a shell. In Consul 1.0, the Args array was added so that checks can be run without a shell. The Script field is deprecated, and you should include the shell in the Args to run under a shell, eg. "args": ["sh", "-c", "..."].
        /// </summary>
        public string[] Args { get; set; }
        /// <summary>
        /// Specifies that the check is a Docker check, and Consul will evaluate the script every Interval in the given container using the specified Shell. Note that Shell is currently only supported for Docker checks.
        /// </summary>
        public string DockerContainerID { get; set; }
        /// <summary>
        /// shell
        /// </summary>
        public string Shell { get; set; }
        /// <summary>
        /// Specifies an HTTP check to perform a GET request against the value of HTTP (expected to be a URL) every Interval. If the response is any 2xx code, the check is passing. If the response is 429 Too Many Requests, the check is warning. Otherwise, the check is critical. HTTP checks also support SSL. By default, a valid SSL certificate is expected. Certificate verification can be controlled using the
        /// </summary>
        public string HTTP { get; set; }
        /// <summary>
        /// Specifies a different HTTP method to be used for an HTTP check. When no value is specified, GET is used.
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        ///  Specifies a set of headers that should be set for HTTP checks. Each header can have multiple values.
        /// </summary>
        public object Header { get; set; }
        /// <summary>
        /// Specifies a TCP to connect against the value of TCP (expected to be an IP or hostname plus port combination) every Interval. If the connection attempt is successful, the check is passing. If the connection attempt is unsuccessful, the check is critical. In the case of a hostname that resolves to both IPv4 and IPv6 addresses, an attempt will be made to both addresses, and the first successful connection attempt will result in a successful check.
        /// </summary>
        public string TCP { get; set; }

        /// <summary>
        /// Specifies this is a TTL check, and the TTL endpoint must be used periodically to update the state of the check.
        /// </summary>
        public string TTL { get; set; }
        /// <summary>
        /// Specifies if the certificate for an HTTPS check should not be verified.
        /// </summary>
        public string TLSSkipVerify { get; set; }

        /// <summary>
        /// Specifies the ID of a service to associate the registered check with an existing service provided by the agent.
        /// </summary>
        public string ServiceID { get; set; }

        /// <summary>
        /// Specifies the initial status of the health check.
        /// </summary>
        public string Satus { get; set; }
    }
}
