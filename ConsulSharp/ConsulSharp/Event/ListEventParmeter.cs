using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// List Event
    /// </summary>
    public class ListEventParmeter
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }    

        /// <summary>
        /// node
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// service
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// tag
        /// </summary>
        public string Tag { get; set; }
    }
}
