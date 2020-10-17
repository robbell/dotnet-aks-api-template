using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
#if (enableLogging)
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.Extensions.Configuration;
#endif

namespace AksApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if (enableLogging)
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            string instrumentationKey = config["ApplicationInsights:InstrumentationKey"];

            CreateHostBuilder(args, instrumentationKey).Build().Run();
#else
            CreateHostBuilder(args).Build().Run();
#endif
        }

#if (enableLogging)
        public static IHostBuilder CreateHostBuilder(string[] args, string instrumentationKey) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureLogging(
                        builder =>
                        {
                            builder.AddApplicationInsights(instrumentationKey);
                            builder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);
                            builder.AddConsole();
                        });
                });
#else
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
#endif
    }
}