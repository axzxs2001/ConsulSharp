using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Catalog Entity Check
    /// </summary>
    public class CatalogEntityCheck
    {
        /// <summary>
        /// Node Name
        /// </summary>
        public string Node
        { get; set; }
        /// <summary>
        /// Check ID
        /// </summary>
        public string CheckID
        { get; set; }
        /// <summary>
        /// Check Name
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Check Status(passing, warning, or critical)
        /// </summary>
        public string Status
        { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes
        { get; set; }
     
        /// <summary>
        /// Service ID
        /// </summary>
        public string ServiceID
        { get; set; }        
 
        /// <summary>
        /// Definition
        /// </summary>
        public object Definition { get; set; }
      
    }
}
