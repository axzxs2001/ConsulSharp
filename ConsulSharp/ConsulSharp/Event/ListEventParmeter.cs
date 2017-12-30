using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Event
{
    /// <summary>
    /// List Event
    /// </summary>
    public class ListEventParmeter
    {
        /// <summary>
        /// Specifies the name of the event to filter. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Specifies a regular expression to filter by node name. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// Specifies a regular expression to filter by service name. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        ///  Specifies a regular expression to filter by tag. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string Tag { get; set; }
    }
}
