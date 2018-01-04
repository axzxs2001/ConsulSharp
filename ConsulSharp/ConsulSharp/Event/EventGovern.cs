using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Event
{
    /// <summary>
    /// Event Govern
    /// </summary>
    public class EventGovern : Govern
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public EventGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// Fire Event,This endpoint triggers a new user event.
        /// </summary>
        /// <param name="firEventParmeter">Fire Event Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, FireEvent fireEvent)> FireEvent(FireEventParmeter fireEventParmeter)
        {
            return await Put<FireEventParmeter, FireEvent>(fireEventParmeter, $"/event/fire/{fireEventParmeter.Name}");
        }
        /// <summary>
        /// Fire Event,This endpoint returns the most recent events known by the agent. As a consequence of how the event command works, each agent may have a different view of the events. Events are broadcast using the gossip protocol, so they have no global ordering nor do they make a promise of delivery.
        /// </summary>
        /// <param name="listEventParmeter">List Event Parmeter</param>
        /// <returns></returns>
        public async Task<FireEvent[]> EventList(ListEventParmeter listEventParmeter)
        {
            return await Get<FireEvent[], ListEventParmeter>($"/event/list", listEventParmeter);
        }
    }
}
