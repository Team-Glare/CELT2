using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CELTAPI.Utilities
{
    public class ServerClient : IServerClient
    {
        #region Fields

        private readonly AppSettings _appSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion Fields

        #region Ctor

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

        public async Task<TResult> GetAsync<TResult>(string relativeUrl)
        {
            var response = await GetHttpClient().GetAsync(CreateUri(relativeUrl));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(content);
            return result;
        }

        public async Task<TResult> PostAsync<TResult, TPayload>(string relativeUrl, TPayload payload)
        {
            var response = await GetHttpClient().PostAsync(CreateUri(relativeUrl), CreateHttpContent(payload));

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(content);
            return result;
        }

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

        private Uri CreateUri(string relativeUrl)
        {
            var uri = new Uri(new Uri(_appSettings.ServerBaseURL), relativeUrl);
            return uri;
        }

        private StringContent CreateHttpContent<T>(T item, string mediaType = "application/json")
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, mediaType);
            return content;
        }

        private HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient();

            return client;
        }

        #endregion Private methods
    }
}
