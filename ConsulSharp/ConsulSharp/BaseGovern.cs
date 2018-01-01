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
        readonly string urlPrefix = "v1";

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
        /// get
        /// </summary>
        /// <typeparam name="T">back type</typeparam>
        /// <param name="url">request url</param>
        /// <param name="dataCenter">datacenter</param>
        /// <returns></returns>
        protected async Task<T> Get<T>(string url, string dataCenter = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}{(!string.IsNullOrEmpty(dataCenter) ? $"?dc={dataCenter}" : "")}");
            var response = await client.GetAsync($"/{urlPrefix}/{url}");
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

        protected async Task<T> Get<T, W>(string url, W inEntity) where W : class, new()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}");
            var parString = GetUrlParmeter<W>(inEntity);
            if (!string.IsNullOrEmpty(parString))
            {
                url += $"?{parString}";
            }
            var response = await client.GetAsync($"/{urlPrefix}/{url}");
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

        string GetUrlParmeter<W>(W inEntity) where W : class, new()
        {
            var parmeterString = new StringBuilder();
            foreach (var pro in inEntity.GetType().GetProperties())
            {
                if (((W)pro.GetValue(inEntity, null)) != default(W))
                {
                    parmeterString.Append($"{pro.Name}={pro.GetValue(inEntity, null)}&");
                }
            }
            return parmeterString.ToString().Trim('&');
        }


        /// <summary>
        /// get
        /// </summary>
        /// <param name="url">request url</param>
        /// <param name="dataCenter">datacenter</param>
        /// <returns></returns>
        protected async Task<string> Get(string url, string dataCenter = null)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{_baseAddress}{(!string.IsNullOrEmpty(dataCenter) ? $"?dc={dataCenter}" : "")}");
            var response = await client.GetAsync($"/{urlPrefix}/{url}");
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// put
        /// </summary>
        /// <typeparam name="T">register type</typeparam>
        /// <param name="entity">register entity</param>
        /// <param name="url">put url</param>
        /// <returns></returns>
        protected async Task<(bool result, string backJson)> Put<T>(T entity, string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseAddress);
            var json = JsonConvert.SerializeObject(entity);
            var stream = new MemoryStream(Encoding.Default.GetBytes(json));
            var content = new StreamContent(stream);
            var response = await client.PutAsync($"/{urlPrefix}/{url}", content);
            var backJson = await response.Content.ReadAsStringAsync();
            return (result: response.StatusCode == System.Net.HttpStatusCode.OK, backJson: backJson);
        }

        /// <summary>
        /// put with parmeter and back parmeter
        /// </summary>
        /// <typeparam name="T">in parmeter</typeparam>
        /// <typeparam name="W">out parmeter</typeparam>
        /// <param name="entity">in entity</param>
        /// <param name="url">put url</param>
        /// <returns></returns>
        protected async Task<(bool result, W backEntity)> Put<T, W>(T entity, string url)
        {
            var backResult = await Put(entity, url);
            if (!backResult.result)
            {
                throw new Exception(backResult.backJson);
            }
            var backEntity = JsonConvert.DeserializeObject<W>(backResult.backJson);
            return (backResult.result, backEntity);
        }

        #endregion



    }
}
