using System;
using System.Collections.Generic;
using System.Text;

namespace ConsulSharp
{
    public class TTLCheck : Check
    {
        public string Ttl
        { get; set; }

        public string Notes
        { get; set; }
    }
}
