# ASP.NET Core Web API for AKS - AksApi

This project was created using the **RobBell.AksApi.Template** `dotnet new` template. For more information, visit the project homepage:

https://github.com/robbell/dotnet-aks-api-template/

## Enabled features

* `SampleController` sample endpoint
* **Docker** containerisation
* **Helm** charts for deploying to Kubernetes
//#if (enableOpenApi)
* **OpenAPI** support (Swagger)
//#endif
//#if (enableHealthCheck)
* **Health checks** including Kubernetes liveness and readiness probes
//#endif
//#if (enableLogging)
* Logging configuration with **AppInsights**
//#endif

## Project overview

* `chart/` - Helm Charts for deploying to Kubernetes
    * `Chart.yaml`
    * `values.yaml` - includes a reference to the published image
    * `template/`
        * `deployment.yaml`
        * `service.yaml`
* `Controllers/`
    * `v1/`
        * `SampleController.cs` - Sample HTTP endpoint
//#if (enableHealthCheck)
* `HealthChecks/`
    * `LiveHealthCheck.cs` - used by the Kubernetes liveness probe
    * `ReadyHealthCheck.cs` - used by the Kubernetes readiness probe
//#endif
* `Properties/`
    * `launchsettings.json`
* `AksApi.csproj` - ASP.NET Web API project
//#if (enableLogging)
* `appsettings.json` - includes AppInsights instrumentation key
//#endif
* `Dockerfile` - Docker containerisation
* `Program.cs`
* `README.md` - this file
* `Startup.cs`
