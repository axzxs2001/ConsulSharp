using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp
{
    /// <summary>
    /// Event Govern
    /// </summary>
    public class EventGovern: Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public EventGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }
        /// <summary>
        /// Fire Event
        /// </summary>
        /// <param name="firEventParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, FireEvent fireEvent)> FireEvent(FireEventParmeter firEventParmeter)
        {
            return await Put<FireEventParmeter, FireEvent>(firEventParmeter, $"/event/fire");
        }

    }
}
