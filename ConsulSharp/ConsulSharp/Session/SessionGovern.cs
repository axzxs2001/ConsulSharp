using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.Session
{
    /// <summary>
    /// Session Govern
    /// </summary>
    public class SessionGovern : Govern
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public SessionGovern(string baseAddress = "http://localhost:8500") : base(baseAddress)
        {
        }
        /// <summary>
        /// This endpoint initializes a new session. Sessions must be associated with a node and may be associated with any number of checks.
        /// </summary>
        /// <param name="createSessionParmeter">Create Session Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, CreateSessionResult createSessionResult)> CreateSession(CreateSessionParmeter createSessionParmeter)
        {
            return await Put<CreateSessionParmeter, CreateSessionResult>(createSessionParmeter, $"/session/create");
        }
        /// <summary>
        /// This endpoint destroys the session with the given name. If the session UUID is malformed, an error is returned. If the session UUID does not exist or already expired, a 200 is still returned (the operation is idempotent).
        /// </summary>
        /// <param name="deleteSessionParmeter">Delete Session Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, bool deleteSessionResult)> DeleteSession(DeleteSessionParmeter deleteSessionParmeter)
        {
            return await Put<DeleteSessionParmeter, bool>(deleteSessionParmeter, $"/session/destroy/{deleteSessionParmeter.UUID}");
        }

        /// <summary>
        /// This endpoint returns the requested session information.
        /// </summary>
        /// <param name="readSessionParmeter">Read Session Parmeter</param>
        /// <returns></returns>
        public async Task<ReadSessionResult[]> ReadSession(DeleteSessionParmeter readSessionParmeter)
        {
            return await Get<ReadSessionResult[], DeleteSessionParmeter>($"/session/info/{readSessionParmeter.UUID}", readSessionParmeter);
        }

        /// <summary>
        /// This endpoint returns the active sessions for a given node.
        /// </summary>
        /// <param name="listSessionsForNodeParmeter">List Sessions For Node Parmeter</param>
        /// <returns></returns>
        public async Task<ReadSessionResult[]> ListSessionsForNode(ListSessionsForNodeParmeter listSessionsForNodeParmeter)
        {
            return await Get<ReadSessionResult[], ListSessionsForNodeParmeter>($"/Session/node/{listSessionsForNodeParmeter.Node}", listSessionsForNodeParmeter);
        }
        /// <summary>
        /// This endpoint returns the list of active sessions.
        /// </summary>
        /// <param name="listSessionsParmeter">List Sessions Parmeter</param>
        /// <returns></returns>
        public async Task<ReadSessionResult[]> ListSessions(ListSessionsParmeter   listSessionsParmeter)
        {
            return await Get<ReadSessionResult[], ListSessionsParmeter>($"/Session/list", listSessionsParmeter);
        }

        /// <summary>
        /// This endpoint renews the given session. This is used with sessions that have a TTL, and it extends the expiration by the TTL.
        /// </summary>
        /// <param name="renewSessionParmeter">Renew Session Parmeter</param>
        /// <returns></returns>
        public async Task<RenewSessionResult[]> RenewSession(DeleteSessionParmeter renewSessionParmeter)
        {
            return await Get<RenewSessionResult[], DeleteSessionParmeter>($"/Session/list", renewSessionParmeter);
        }
    }
}
