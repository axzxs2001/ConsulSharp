using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// List Checks for Node
    /// </summary>
    public class CheckNodeResult: BaseCheckNode
    {
        /// <summary>
        /// id
        /// </summary>
        public string ID { get; set; }       
    }
}
