using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var request = new HttpRequestMessage(HttpMethod.Post,"/connect/token");
            request.Content = new FormUrlEncodedContent(new Dictionary<string,string>{
                ["grant_type"] = "password",
                ["username"] = "alice",
                ["password"] = "Pass123$"
            });
            var response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
            var payload = response.Content.ReadAsStringAsync().Result;            
            Console.WriteLine("{0}",payload);
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
