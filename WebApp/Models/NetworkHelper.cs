using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NetworkHelper
    {
        private static NetworkHelper instance { get; set; }
        private string URI { get; set; }
        public static NetworkHelper getInstance()
        {
            return instance;
        }

        public NetworkHelper(string uri)
        {
            URI = uri;
        }

        public static void init(string uri)
        {
            instance = new NetworkHelper(uri);
        }

        public async Task<T> Get<T>(string action)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                var apiResponse = await client.GetStringAsync(action);
                return System.Text.Json.JsonSerializer.Deserialize<T>(apiResponse);
            }
        }

        public async Task<T> Post<T>(string param, string action)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                var apiResponse = client.PostAsync(action, new StringContent(param, Encoding.UTF8, "application/json")).Result;
                return System.Text.Json.JsonSerializer.Deserialize<T>(apiResponse.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<T> Delete<T>(string action)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                var apiResponse = await client.DeleteAsync(action);
                return System.Text.Json.JsonSerializer.Deserialize<T>(apiResponse.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<T> Put<T>(string param, string action)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                var apiResponse = client.PutAsync(action, new StringContent(param, Encoding.UTF8, "application/json")).Result;
                return System.Text.Json.JsonSerializer.Deserialize<T>(apiResponse.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
