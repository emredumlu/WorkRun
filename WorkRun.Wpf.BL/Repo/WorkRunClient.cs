using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WorkRun.Core;

namespace WorkRun.Client.BL
{
    public class WorkRunClient
    {
        private readonly HttpClient _client;
        public WorkRunClient()
        {
            _client = GetClient();
        }

        public async Task<T> Get<T>(string url)
        {
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Hata-{response.StatusCode}");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, RunHelper.GetJsonSettings());
            }
        }
        public async Task<T> Post<T>(object entity, string url)
        {
            var response = await _client.PostAsync(url, new JsonContent(entity));
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Hata-{response.StatusCode}");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content, RunHelper.GetJsonSettings());
            }
        }

        private static HttpClient GetClient()
        {
            HttpClient client = new();
            client.BaseAddress = new(RunGlobal.Address);
            client.DefaultRequestHeaders.Add("db-type", RunGlobal.DbType);
            return client;
        }
    }

    public class JsonContent : StringContent
    {
        public JsonContent(object entity) : base(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json") { }
        public JsonContent(object entity, Encoding encoding, string mediaType) : base(JsonSerializer.Serialize(entity), encoding, mediaType) { }
    }
}
