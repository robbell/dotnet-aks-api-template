# ASP.NET Core Web API for AKS template

A `dotnet new` template for creating a fully-featured, 12 Factor, ASP.NET Core Web API for AKS.

## Installation

```
dotnet new -i RobBell.AksApi.Template::1.0.2
```

## Usage

```
dotnet new aksapi -n MyApi
```

## Includes:

* [x] Installation notes
* [x] Template packaging on all platforms ([.csproj package](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates#packing-a-template-into-a-nuget-package-nupkg-file))
* [x] Template package versioning
* [x] Removal of package warnings
* [x] Sample endpoint (versioning?)

## Upcoming:

* [ ] Tests project
* [ ] Dockerfile (including test running)
* [ ] Swagger
* [ ] Health check
* [ ] AppInsights
* [ ] Helm charts (best way to include these?)
* [ ] YAML release pipeline (Azure DevOps or GitHub Actions?)
* [ ] Post actions (run 'dotnet restore'?)
* [ ] Other [12 Factor](https://12factor.net/) app traits
* [ ] Other creation parameters (Port? EnablingAuthentication?)
* [ ] Reintroduce launchsettings.json if useful
* [ ] No unused references
