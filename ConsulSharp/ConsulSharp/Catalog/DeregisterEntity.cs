using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// deregister entity
    /// </summary>
    public class DeCatalogEntity
    {
        /// <summary>
        /// datacenter
        /// </summary>
        public string Datacenter { get; set; }
        /// <summary>
        /// node
        /// </summary>
        public string Node { get; set; }
        /// <summary>
        /// check id
        /// </summary>
        public string CheckID { get; set; }
        /// <summary>
        /// service id
        /// </summary>
        public string ServiceID { get; set; }
    }
}
