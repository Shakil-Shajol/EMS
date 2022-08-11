using System.Net.Http.Headers;

namespace EMS.Client.Helpers
{
    public class HttpCallHandler
    {
        private readonly IConfiguration configuration;

        public HttpCallHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> GetValue(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBaseUrl"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                return "{}";
            }
        }

        public async Task<string> PostAsync(string apiUrl,object obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(configuration.GetValue<string>("ApiBaseUrl"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, obj);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                return "{}";
            }
        }
    }
}
