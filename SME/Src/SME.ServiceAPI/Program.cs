using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SME.ServiceAPI
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .AddUserSecrets<Startup>()
           .Build();
        public static void Main(string[] args)
        {
           
            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(Configuration)                          
                        .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateWebHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

           // CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>            
            WebHost.CreateDefaultBuilder(args)                   
                .UseStartup<Startup>()
                .UseSerilog();

         
    }
}
