/**
* @license
* Copyright Team Glare. All Rights Reserved.
*
* Use of this source code is governed by an MIT-style license that can be
* found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
*/

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CELTAPI.Utilities
{
    /// <summary>
    /// Defines a server client with the GET, POST and PUT methods.
    /// </summary>
    public class ServerClient : IServerClient
    {
        #region Fields

        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Fields

        #region Ctor
        /// <summary>
        /// Constructor for server client with injected dependencies.
        /// </summary>
        /// <param name="httpClientFactory">Inject IHttpClientFactory</param>
        /// <param name="httpContextAccessor">Inject IHttpContextAccessor</param>
        /// <param name="options">Inject optional AppSettings</param>
        public ServerClient(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion Ctor

        #region Public methods
        /// <summary>
        /// Defines the GetAsync
        /// </summary>
        /// <typeparam name="TResult">Return result type.</typeparam>
        /// <param name="relativeUrl">The relative URL to be called.</param>
        /// <returns></returns>
        public async Task<TResult> GetAsync<TResult>(string relativeUrl)
        {
            var response = await GetHttpClient().GetAsync(CreateUri(relativeUrl));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(content);
            return result;
        }

        /// <summary>
        /// Defines the PostAsync
        /// </summary>
        /// <typeparam name="TResult">Return result type.</typeparam>
        /// <typeparam name="TPayload">The input Paylod type.</typeparam>
        /// <param name="relativeUrl">The relative URL to be called.</param>
        /// <param name="payload">The input Paylod.</param>
        /// <returns>The result of the PostAsync method.</returns>
        public async Task<TResult> PostAsync<TResult, TPayload>(string relativeUrl, TPayload payload)
        {
            var response = await GetHttpClient().PostAsync(CreateUri(relativeUrl), CreateHttpContent(payload));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(content);
            return result;
        }

        /// <summary>
        /// Defines the PutAsync
        /// </summary>
        /// <typeparam name="TResult">Return result type.</typeparam>
        /// <typeparam name="TPayload">The input Paylod type.</typeparam>
        /// <param name="relativeUrl">The relative URL to be called.</param>
        /// <param name="payload">The input Paylod.</param>
        /// <returns>The result of the PutAsync method.</returns>
        public async Task<TResult> PutAsync<TResult, TPayload>(string relativeUrl, TPayload payload)
        {
            var response = await GetHttpClient().PutAsync(CreateUri(relativeUrl), CreateHttpContent(payload));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(content);
            return result;
        }

        #endregion Public methods

        #region Private methods
        /// <summary>
        /// Creates URI from relative URL.
        /// </summary>
        /// <param name="relativeUrl">The relative URL input.</param>
        /// <returns>The URI from the relative and server base URL.</returns>
        private Uri CreateUri(string relativeUrl)
        {
            var uri = new Uri(new Uri(_appSettings.ServerBaseURL), relativeUrl);
            return uri;
        }

        /// <summary>
        /// Creates Http Contents afer serializing the object into Json.
        /// </summary>
        /// <typeparam name="T">Type of the input.</typeparam>
        /// <param name="item">Input to be serialized.</param>
        /// <param name="mediaType">The mediatype. The default mediatype is application/json.</param>
        /// <returns>The Http content.</returns>
        private StringContent CreateHttpContent<T>(T item, string mediaType = "application/json")
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, mediaType);
            return content;
        }

        /// <summary>
        /// Creates Http client using the Http Client factory.
        /// </summary>
        /// <returns>Http client instance.</returns>
        private HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient();

            return client;
        }

        #endregion Private methods
    }
}
