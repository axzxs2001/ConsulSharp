using ConsulSharp.Agent.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Health
{
    /// <summary>
    /// List Nodes for Service
    /// </summary>
    public class NodeService
    {
        /// <summary>
        /// node
        /// </summary>
        public BaseNode Node { get; set; }
        /// <summary>
        /// service
        /// </summary>
        public  ListService Service { get; set; }

        /// <summary>
        /// checks
        /// </summary>
        public BaseCheckNode Checks { get; set; }
    }
}
