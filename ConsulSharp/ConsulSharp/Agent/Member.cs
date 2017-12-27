using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// agent List Members
    /// </summary>
    public class Member
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// address
        /// </summary>
        public string Addr { get; set; }
        /// <summary>
        /// port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// status
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// protocol min
        /// </summary>
        public int ProtocolMin { get; set; }
        /// <summary>
        /// protocol max
        /// </summary>
        public int ProtocolMax { get; set; }
        /// <summary>
        /// protocol cur
        /// </summary>
        public int ProtocolCur { get; set; }
        /// <summary>
        /// delegate min
        /// </summary>
        public int DelegateMin { get; set; }
        /// <summary>
        /// delegate max
        /// </summary>
        public int DelegateMax { get; set; }
        /// <summary>
        /// delegate cur
        /// </summary>
        public int DelegateCur { get; set; }
    }
}
