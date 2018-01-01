using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp.Agent.Check
{
    public abstract class Check
    {
        public string ID
        { get; set; }
        public string Name
        { get; set; }
    }
}
