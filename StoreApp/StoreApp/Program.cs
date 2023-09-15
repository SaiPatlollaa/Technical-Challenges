using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunAsync().GetAwaiter().GetResult();
        }
        public class HttpResponse
        {
            public string Login { get; set; }
            public int Id { get; set; }
            public string Node_id { get; set; }
            public string Url { get; set; }
            public string Repos_url { get; set; }
            public string Events_url { get; set; }
            public string Hooks_url { get; set; }
            public string Issues_url { get; set; }
            public string Members_url { get; set; }
            public string Public_members_url { get; set; }
            public string Avatar_url { get; set; }
            public string Description { get; set; }

        }
        static HttpClient client = new HttpClient();

        public static async Task<string> GetHttpsResponse(string url)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            var jsonString = await client.GetStringAsync(url);
            return jsonString;
        }
        static async Task RunAsync()
        {
            try
            {
                string url = @"https://api.github.com/users/hadley/orgs";
                string jsonResponse = await GetHttpsResponse(url);
                List<HttpResponse> result = JsonConvert.DeserializeObject<List<HttpResponse>>(jsonResponse);
                var orderedList = result.OrderByDescending(p => p.Id).ToList();
                var maxId = orderedList.First();
                var minId = orderedList.Last();
                List < HttpResponse > finalResponseList= new List<HttpResponse>();
                finalResponseList.Add(maxId);
                finalResponseList.Add(minId);
                string finalResponse= JsonConvert.SerializeObject(finalResponseList);
                Console.WriteLine(finalResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
