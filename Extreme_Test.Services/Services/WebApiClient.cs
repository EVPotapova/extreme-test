using Extreme_Test.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Extreme_Test.Services.Services
{
    public class E1Exception : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public E1Exception(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Throws an exception if the <see cref="P:System.Net.Http.HttpResponseMessage.IsSuccessStatusCode"/> property for the HTTP response is false.
        /// </summary>
        /// <param name="httpResponseMessage"></param>
        public static async Task EnsureResponseAsync(this HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                throw new E1Exception(responseBody, httpResponseMessage.StatusCode);
            }
        }
    }

    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }

    public class WebApiClient : IWebApiClient
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using (var client = CreateHttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                await responseMessage.EnsureResponseAsync();
                var result = await responseMessage.Content.ReadAsJsonAsync<T>();
                return result;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
