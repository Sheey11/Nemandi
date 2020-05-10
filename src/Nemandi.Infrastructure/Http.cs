using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

namespace Nemandi.Infrastructure {
    public static class Http {
        public async static Task<byte[]> GetAsync(string url){
            var client = new HttpClient();
            try {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsByteArrayAsync();
                return responseBody;
            } catch(HttpRequestException e) {
                throw e;
            }
        }
        public static byte[] Get(string url){
            return Task.Run(() => GetAsync(url)).GetAwaiter().GetResult();
        }
        public static string GetString(string url) {
            var bytes = Task.Run(() => GetAsync(url)).GetAwaiter().GetResult();
            return Encoding.UTF8.GetString(bytes);
        }

        public async static Task<byte[]> PostAsync(string url, string json){
            var client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try {
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsByteArrayAsync();
                return responseBody;
            } catch(HttpRequestException e) {
                throw e;
            }
        }
        public static byte[] Post(string url, string json){
            return Task.Run(() => PostAsync(url, json)).GetAwaiter().GetResult();
        }
        public static string PostString(string url, string json) {
            var bytes = Task.Run(() => PostAsync(url, json)).GetAwaiter().GetResult();
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
