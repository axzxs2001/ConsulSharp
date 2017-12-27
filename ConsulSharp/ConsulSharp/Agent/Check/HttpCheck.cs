using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    public class HttpCheck:Check
    {
        public string Http
        { get; set; }

        public bool Tls_Skip_Verify
        { get; set; }

        public string Method
        { get; set; }

        public object Header
        { get; set; }

        public string Interval
        { get; set; }

        public string TimeOut
        { get; set; }
    }
}
