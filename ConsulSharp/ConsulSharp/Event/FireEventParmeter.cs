using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Event
{
    /// <summary>
    /// Fire Event
    /// </summary>
    public class FireEventParmeter
    {
        /// <summary>
        ///  Specifies the name of the event to fire. This is specified as part of the URL. This name must not start with an underscore, since those are reserved for Consul internally.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }

        /// <summary>
        /// Specifies a regular expression to filter by node name. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// Specifies a regular expression to filter by service name. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Specifies a regular expression to filter by tag. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Tag { get; set; }
    }
}
