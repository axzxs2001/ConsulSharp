using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Catalog
{
    /// <summary>
    /// List Service Parmeter
    /// </summary>
    public class ListServicesParmeter
    {
        /// <summary>
        /// Specifies the datacenter to query. This will default to the datacenter of the agent being queried. This is specified as part of the URL as a query parameter.
        /// </summary>
        public string DC { get; set; }

        /// <summary>
        /// Specifies a desired node metadata key/value pair of the form key:value. This parameter can be specified multiple times, and will filter the results to nodes with the specified key/value pairs. This is specified as part of the URL as a query parameter.
        /// </summary>
        [FieldName("Node-Meta")]
        public string NodeMeta  { get; set; }
    }
}
