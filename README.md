# ASP.NET Core Web API for AKS template

A `dotnet new` template for creating a fully-featured, 12 Factor, ASP.NET Core Web API for AKS.

## Installation

```
dotnet new -i RobBell.AksApi.Template::1.0.2
```

## Usage

To create a new project named *MyApi*:

```
dotnet new aksapi -n MyApi
```

To customise the name of the default controller:

```
dotnet new aksapi -n MyApi --controllerName MyController
```

## Includes:

- [x] Installation notes
- [x] Template packaging on all platforms ([.csproj package](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates#packing-a-template-into-a-nuget-package-nupkg-file))
- [x] Template package versioning
- [x] Removal of package warnings
- [x] Sample endpoint (versioning?)
- [x] Dockerfile
- [x] No unused references

## Upcoming:

- [ ] Optional Swagger
- [ ] Health check endpoint
- [ ] AppInsights configuration
- [ ] Helm charts
- [ ] YAML release pipeline (Azure DevOps or GitHub Actions?)
- [ ] Post actions (run 'dotnet restore'?)

## To be confirmed:

- [ ] Tests project (includes running in Dockerfile) - are these valuable? Forces this to become a multi-project, and possibly solution-creating template
- [ ] Other [12 Factor](https://12factor.net/) app traits - look at what would be useful to include
- [ ] Other creation parameters (Port? EnablingAuthentication?)
- [ ] Reintroduce launchsettings.json if useful