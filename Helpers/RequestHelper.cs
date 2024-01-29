using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestPdb.Helpers
{
    public class RequestHelper<T>
    {
        private readonly HttpClient _client;
        private string _url;

        public RequestHelper(HttpClient client, string baseUrl, string urlSuffix)
        {
            _url = $"{baseUrl}/{urlSuffix}";
            _client = client;
        }

        private async Task<T> GetDataAsync()
        {
            var response = await _client.GetAsync(_url);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);
        }

        private async Task<T> PostDataAsync(HttpContent content)
        {
            var response = await _client.PostAsync(_url, content);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);
        }

        private async Task<T> PutDataAsync(HttpContent content)
        {
            var response = await _client.PutAsync(_url, content);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);
        }

        public T GetData()
        {
            var task = GetDataAsync();
            task.Wait();
            return task.Result;
        }

        public T PostData()
        {
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string,string>>());
            var task = PostDataAsync(content);
            task.Wait();
            return task.Result;
        }

        public T PostData(int value, string name)
        {
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(name, value.ToString()) });
            var task = PostDataAsync(content);
            task.Wait();
            return task.Result;
        }

        public T PutData(int value, string name)
        {
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>(name, value.ToString()) });
            var task = PutDataAsync(content);
            task.Wait();
            return task.Result;
        }

        public T PutData()
        {
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
            var task = PutDataAsync(content);
            task.Wait();
            return task.Result;
        }
    }
}
