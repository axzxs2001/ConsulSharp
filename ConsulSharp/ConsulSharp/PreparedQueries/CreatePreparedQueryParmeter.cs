using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Create Prepared Query Parmeter
    /// </summary>
    public class CreatePreparedQueryParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }
        /// <summary>
        /// Specifies an optional friendly name that can be used to execute a query instead of using its ID.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the ID of an existing session. This provides a way to automatically remove a prepared query when the given session is invalidated. If not given the prepared query must be manually removed when no longer needed.
        /// </summary>
        public string Session { get; set; }
        /// <summary>
        /// Specifies the ACL token to use each time the query is executed. This allows queries to be executed by clients with lesser or even no ACL Token, so this should be used with care. The token itself can only be seen by clients with a management token. If the Token field is left blank or omitted, the client's ACL Token will be used to determine if they have access to the service being queried. If the client does not supply an ACL Token, the anonymous token will be used.
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        ///  Specifies the structure to define the query's behavior.
        /// </summary>
        public Service Service { get; set; }
        /// <summary>
        /// Specifies the TTL duration when query results are served over DNS. If this is specified, it will take precedence over any Consul agent-specific configuration. 
        /// </summary>
        public DNS DNS { get; set; } 
    }
}
