using AksApi.Options;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
#if (enableSerolog)
using Serilog;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.Sinks.ApplicationInsights.TelemetryConverters;
using System;
using System.IO;
#endif

namespace AksApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if (enableSerolog)
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();
#endif

            var host = CreateHostBuilder(args).Build();
#if (enableSerolog)
            ConfigureLogger(config, host.Services);
#endif
            host.Run();

        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
#if (enableSerolog)
            .UseStartup<Startup>()
            .UseSerilog();
#else
            .UseStartup<Startup>();
#endif

#if (enableSerolog)
        public static void ConfigureLogger(IConfigurationRoot configurationRoot, IServiceProvider services)
        {
            var applicationInsightsOptions = new ApplicationInsightsOptions();
            configurationRoot.GetSection("ApplicationInsights").Bind(applicationInsightsOptions);
            var environmentOptions = new EnvironmentOptions();
            configurationRoot.GetSection("environmentoptions").Bind(environmentOptions);

            var config = new LoggerConfiguration();

            config.MinimumLevel.Is(LogEventLevelFromConfig(applicationInsightsOptions.MinimumLogLevel));
            config.MinimumLevel.Override("Microsoft", LogEventLevel.Error);
            config.MinimumLevel.Override("System", LogEventLevel.Error);

            config.WriteTo.Console(
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {EventCode}{Message:lj}{NewLine}{SavedItemMessage}{Exception}{NewLine}", standardErrorFromLevel: LogEventLevel.Verbose);

            config.WriteTo.ApplicationInsights(applicationInsightsOptions.InstrumentationKey, new EventTelemetryConverter(), LogEventLevelFromConfig(applicationInsightsOptions.MinimumLogLevel));

            config.Enrich.WithProperty("ApplicationName", environmentOptions.ApplicationName);
            config.Enrich.WithProperty("Region", environmentOptions.Region);
            config.Enrich.WithProperty("Environment", environmentOptions.EnvironmentName);
            config.Enrich.FromLogContext();

            Log.Logger = config.CreateLogger();
        }

        private static LogEventLevel LogEventLevelFromConfig(string logEventLevel)
        {
            return !Enum.TryParse(logEventLevel, true, out LogEventLevel level) ? LogEventLevel.Information : level;
        }
#endif
    }
}