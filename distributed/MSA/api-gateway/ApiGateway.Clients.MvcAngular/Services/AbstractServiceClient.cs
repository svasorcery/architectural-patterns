using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ApiGateway.Clients.MvcAngular.Services
{
    using ApiGateway.Clients.MvcAngular.Models;

    public abstract class AbstractServiceClient
    {
        protected abstract string BaseUrl { get; }
        protected virtual bool CamelCaseSerialization => false;

        private readonly HttpClient _client;
        private readonly JsonSerializer _json;
        private readonly ILogger _logger;

        public AbstractServiceClient(ILogger logger)
        {
            _json = new JsonSerializer();
            if (CamelCaseSerialization)
            {
                _json.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                {
                    NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy()
                };
            }
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(BaseUrl.EndsWith("/") ? BaseUrl : BaseUrl + "/");
        }


        public async Task<HttpClient> GetClient()
        {
            using (var writer = new StringWriter())
            {
                _json.Serialize(writer, new { Username = "svasorcery", Password = "gfhjkm123" });

                var response = await _client.PostAsync(
                    "access-token",
                    new StringContent(writer.GetStringBuilder().ToString(), System.Text.Encoding.UTF8, "application/json")
                );

                var tokenResponse = await ReadAs<TokenResponse>(response.Content);

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

                return _client;
            }
        }
        
        public async Task<T> ReadAs<T>(HttpContent content)
        {
            using (var stream = await content.ReadAsStreamAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    return _json.Deserialize<T>(new JsonTextReader(reader));
                }
            }
        }

        public T ReadAs<T>(string content)
        {
            using (var reader = new StringReader(content))
            {
                return _json.Deserialize<T>(new JsonTextReader(reader));
            }
        }

        protected async Task<T> Get<T>(string url)
        {
            var client = await GetClient();

            _logger.LogInformation("GET {BaseUrl}/{Url}", BaseUrl, url);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode == false)
            {
                _logger.LogWarning("Unsuccessful status code GET {BaseUrl}/{Url} {StatusCode}",
                    BaseUrl, url, response.StatusCode);

                var error = await ReadAs<ApiErrorResponseResult>(response.Content);
                throw new ApiException(error);
            }

            return await ReadAs<T>(response.Content);
        }

        protected async Task<TOut> Post<TOut, TIn>(string url, TIn p)
        {
            var client = await GetClient();

            _logger.LogInformation("POST {BaseUrl}/{Url}", BaseUrl, url);

            using (var writer = new StringWriter())
            {
                _json.Serialize(writer, p);
                var response = await client.PostAsync(
                    url, 
                    new StringContent(writer.GetStringBuilder().ToString(), System.Text.Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode == false)
                {
                    _logger.LogWarning("Unsuccessful status code POST {BaseUrl}/{Url} {StatusCode}",
                        BaseUrl, url, response.StatusCode);

                    var error = await ReadAs<ApiErrorResponseResult>(response.Content);
                    throw new ApiException(error);
                }

                return await ReadAs<TOut>(response.Content);
            }
        }

        protected async Task<TOut> Put<TOut, TIn>(string url, TIn p)
        {
            var client = await GetClient();

            _logger.LogInformation("PUT {BaseUrl}/{Url}", BaseUrl, url);

            using (var writer = new StringWriter())
            {
                _json.Serialize(writer, p);
                var response = await client.PutAsync(
                    url,
                    new StringContent(writer.GetStringBuilder().ToString(), System.Text.Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode == false)
                {
                    _logger.LogWarning("Unsuccessful status code PUT {BaseUrl}/{Url} {StatusCode}",
                        BaseUrl, url, response.StatusCode);

                    var error = await ReadAs<ApiErrorResponseResult>(response.Content);
                    throw new ApiException(error);
                }

                return await ReadAs<TOut>(response.Content);
            }
        }

        protected async Task Delete(string url)
        {
            var client = await GetClient();

            _logger.LogInformation("DELETE {BaseUrl}/{Url}", BaseUrl, url);
            var response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode == false)
            {
                _logger.LogWarning("Unsuccessful status code DELETE {BaseUrl}/{Url} {StatusCode}",
                    BaseUrl, url, response.StatusCode);

                var error = await ReadAs<ApiErrorResponseResult>(response.Content);
                throw new ApiException(error);
            }
        }
    }
}
