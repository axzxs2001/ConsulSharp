using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    public class DockerCheck : Check
    {
        public string Docker_Container_ID
        { get; set; }
        public string Shell
        { get; set; }
        public string[] Args
        { get; set; }
        public string Interval
        { get; set; }

      
    }
}
