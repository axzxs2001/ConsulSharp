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
        public async Task<(bool result, FireEvent fireEvent)> FireEvent(FireEventParmeter fireEventParmeter)
        {
            return await Put<FireEventParmeter, FireEvent>(fireEventParmeter, $"/event/fire");
        }
        /// <summary>
        /// Fire Event
        /// </summary>
        /// <param name="firEventParmeter">in parmeter</param>
        /// <returns></returns>
        public async Task<FireEvent[]> FireEvent(ListEventParmeter listEventParmeter)
        {
            var parmeter = new StringBuilder();
            if(!string.IsNullOrEmpty(listEventParmeter.Name))
            {
                parmeter.Append($"&name={listEventParmeter.Name}");
            }
            if (!string.IsNullOrEmpty(listEventParmeter.Node))
            {
                parmeter.Append($"&node={listEventParmeter.Node}");
            }
            if (!string.IsNullOrEmpty(listEventParmeter.Service))
            {
                parmeter.Append($"&node={listEventParmeter.Service}");
            }
            if (!string.IsNullOrEmpty(listEventParmeter.Tag))
            {
                parmeter.Append($"&node={listEventParmeter.Tag}");
            }

            return await Get<FireEvent[]>($"/event/fire?{parmeter.ToString().TrimStart('&')}");
        }
    }
}
