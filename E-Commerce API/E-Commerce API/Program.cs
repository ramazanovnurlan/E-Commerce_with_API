using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using E_Commerce_API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace E_Commerce_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                DatabaseInitializer.Seed(serviceScope);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var asseblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;
                    webBuilder.UseStartup(asseblyName); //Development və Production mühitini ayırmaq üçün Program.cs-də kodu dəyişirik
                    //webBuilder.UseStartup<Startup>();
                });
    }
}
