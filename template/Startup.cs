using Microsoft.AspNetCore.Builder;
#if (enableHealthCheck)
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
#endif
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
#if (enableHealthCheck)
using Microsoft.Extensions.Diagnostics.HealthChecks;
#endif
using Microsoft.Extensions.Hosting;
#if (enableOpenApi)
using Microsoft.OpenApi.Models;
#endif
#if (enableHealthCheck)
using AksApi.HealthChecks;
#endif

namespace AksApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
#if (enableOpenApi)

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AksApi", Version = "v1" });
            });
#endif
#if (enableHealthCheck)

            services.AddHealthChecks()
                .AddCheck<LiveHealthCheck>(
                    "live-health-check",
                    failureStatus: HealthStatus.Degraded,
                    tags: new[] { "live" })
                .AddCheck<ReadyHealthCheck>(
                    "ready-health-check",
                    failureStatus: HealthStatus.Degraded,
                    tags: new[] { "ready" });
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
#if (enableOpenApi)
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AksApi v1"));
#endif
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
#if (enableHealthCheck)

                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("ready")
                });

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("live")
                });
#endif
            });
        }
    }
}