using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.IO;

namespace NathansCRUDWebsite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionKey = File.ReadAllText("appsettings.json");
            JObject jsonObject = JObject.Parse(connectionKey);
            JToken token = jsonObject["DefaultConnection"];
            string connString = token.ToString();
            ProductRepo.connectionString = connString;
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
