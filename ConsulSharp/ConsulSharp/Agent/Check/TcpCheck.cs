using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    public class TcpCheck : Check
    {
        public string Tcp
        { get; set; }

        public string Interval
        { get; set; }

        public string TimeOut
        { get; set; }
    }
}
