using ConsulSharp.Health;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsulSharp.PreparedQueries
{
    /// <summary>
    /// Prepared Queries Govern
    /// </summary>
    public class PreparedQueriesGovern : Govern
    {        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public PreparedQueriesGovern(string baseAddress = "http://localhost:8500"):base(baseAddress)
        {       
        }
        /// <summary>
        /// This endpoint creates a new prepared query and returns its ID if it is created successfully.
        /// </summary>
        /// <param name="createPreparedQueryParmeter">Create Prepared Query Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, CreatePreparedQueryResult createPreparedQueryResult)> CreatePreparedQuery(CreatePreparedQueryParmeter  createPreparedQueryParmeter)
        {
            return await Post<CreatePreparedQueryParmeter, CreatePreparedQueryResult>(createPreparedQueryParmeter, $"/query");
        }

        /// <summary>
        /// This endpoint returns a list of all prepared queries.
        /// </summary>
        /// <param name="readPreparedQueryParmeter">Read Prepared Query Parmeter</param>
        /// <returns></returns>
        public async Task<ReadPreparedQueryResult> ReadPreparedQuery(ReadPreparedQueryParmeter  readPreparedQueryParmeter)
        {
            return await Get<ReadPreparedQueryResult, ReadPreparedQueryParmeter>($"/query", readPreparedQueryParmeter);
        }

        /// <summary>
        /// This endpoint updates an existing prepared query. If no query exists by the given ID, an error is returned.
        /// </summary>
        /// <param name="updatePreparedQueryParmeter">Update Prepared Query Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> UpdatePreparedQuery(UpdatePreparedQueryParmeter  updatePreparedQueryParmeter)
        {
            return await Put<UpdatePreparedQueryParmeter, string>(updatePreparedQueryParmeter, $"/query");
        }
        /// <summary>
        /// This endpoint deletes an existing prepared query. If no query exists by the given ID, an error is returned.
        /// </summary>
        /// <param name="updatePreparedQueryParmeter">Update Prepared Query Parmeter</param>
        /// <returns></returns>
        public async Task<(bool result, string backResult)> DeletePreparedQuery(UpdatePreparedQueryParmeter updatePreparedQueryParmeter)
        {
            return await Delete<UpdatePreparedQueryParmeter, string>(updatePreparedQueryParmeter, $"/query");
        }

        public 
    }
}
