using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Agent.Check
{
    /// <summary>
    /// Deregister Check Parmeter
    /// </summary>
    public class DeregisterCheckParmeter
    {
        /// <summary>
        /// Specifies the unique ID of the check to deregister. This is specified as part of the URL.
        /// </summary>
        public string Check_ID { get; set; }
    }
}
