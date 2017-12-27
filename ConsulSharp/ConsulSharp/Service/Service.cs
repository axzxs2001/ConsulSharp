using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    /// <summary>
    /// Service
    /// </summary>
    public class Service
    {
        public string ID
        { get; set; }

        public string Name
        { get; set; }

        public string[] Tags
        {
            get; set;
        }
        public string Address
        { get; set; }
        public int Port
        { get; set; }
        public bool EnableTagOverride
        { get; set; }
        public Check[] Checks
        { get; set; }
    }
}
