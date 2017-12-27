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
    /// Service Govern
    /// </summary>
    public class Govern
    {
        protected string _baseAddress;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="baseAddress">Base Address</param>
        public Govern(string baseAddress = "http://localhost:8500")
        {
            _baseAddress = baseAddress;
        }
        #region base method
        /// <summary>
        /// base call method
        /// </summary>
        /// <typeparam name="T">back type</typeparam>
        /// <param name="url">request url</param>
        /// <param name="dataCenter">datacenter</param>
        /// <returns></returns>
        protected async Task<T> Get<T>(string url, string dataCenter = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}{(!string.IsNullOrEmpty(dataCenter) ? $"?dc={dataCenter}" : "")}");
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    var entity = JsonConvert.DeserializeObject<T>(json);
                    return entity;
                }
                catch (JsonReaderException)
                {
                    throw new ApplicationException($"back content is error formatter:{json}");
                }
            }
            else
            {
                throw new ApplicationException($"back content is empty.");
            }
        }

        /// <summary>
        /// call url back json
        /// </summary>
        /// <param name="url">request url</param>
        /// <param name="dataCenter">datacenter</param>
        /// <returns></returns>
        protected async Task<string> Get(string url, string dataCenter = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}{(!string.IsNullOrEmpty(dataCenter) ? $"?dc={dataCenter}" : "")}");
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// register
        /// </summary>
        /// <typeparam name="T">register type</typeparam>
        /// <param name="entity">register entity</param>
        /// <param name="url">register url</param>
        /// <returns></returns>
        protected async Task<(bool result, string backJson)> Put<T>(T entity, string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseAddress);
            var json = JsonConvert.SerializeObject(entity);
            var stream = new MemoryStream(Encoding.Default.GetBytes(json));
            var content = new StreamContent(stream);
            var response = await client.PutAsync(url, content);
            var backJson = await response.Content.ReadAsStringAsync();
            return (result: response.StatusCode == System.Net.HttpStatusCode.OK, backJson: backJson);
        }



        #endregion



    }
}
