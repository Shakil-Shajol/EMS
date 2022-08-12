using EMS.Client.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EMS.Client.Helpers
{
    public class HttpCallHandler
    {
        private readonly IConfiguration configuration;

        public HttpCallHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<ResponseDetail<List<T>>> GetAsyc<T>(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBaseUrl"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var output = JsonSerializer.Deserialize<ResponseDetail<List<T>>>(result);
                return output!;
            }
            else
            {
                return default!;
            }
        }

        public async Task<ResponseDetail<T>> GetSingleAsyc<T>(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBaseUrl"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var output = JsonSerializer.Deserialize<ResponseDetail<T>>(result);
                return output!;
            }
            else
            {
                return default!;
            }
        }

        public async Task<ResponseDetail<T>> PostAsync<T>(string apiUrl,T obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBaseUrl"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, obj);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var output = JsonSerializer.Deserialize<ResponseDetail<T>>(result);
                return output!;
            }
            else
            {
                return default!;
            }
        }
    }
}
