using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Agent.Service
{
    /// <summary>
    /// Deregister Service Parmeter
    /// </summary>
    public class DeregisterServiceParmeter
    {
        /// <summary>
        /// Specifies the ID of the service to deregister.This is specified as part of the URL.
        /// </summary>
        public string Service_ID{ get; set; }
    }
}
