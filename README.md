# ASP.NET Core Web API for AKS template

A `dotnet new` template for creating a fully-featured, 12 Factor, ASP.NET Core Web API for AKS.

## Installation

```
dotnet new -i RobBell.AksApi.Template
```

## Usage

To create a new project named *MyApi*:

```
dotnet new aksapi -n MyApi
```

Other options include:

```
--controller-name   The name of the default controller
                    Default: SampleController

--disable-open-api  Disable OpenAPI (Swagger) support
                    Default: false

--skip-restore      Skips the restore of the project on create
                    Default: false
```

## Template features

- [x] Sample endpoint
- [x] Docker containerisation
- [x] OpenAPI support (Swagger)
- [x] Automatic post creation actions - `dotnet restore`
- [ ] Helm charts
    - [x] Deployment and service creation
    - [ ] Image references
    - [ ] Labels
- [x] No unused package references or usings

### In progress

- [ ] Health check endpoint
- [ ] AppInsights configuration
- [ ] YAML release pipeline (Azure DevOps or GitHub Actions?)
- [ ] Clean-up rules
- [ ] Linting

### To be confirmed

- [ ] Tests project (includes running in Dockerfile) - are these valuable? Forces this to become a multi-project, and possibly solution-creating template
- [ ] Other [12 Factor](https://12factor.net/) app traits - look at what would be useful to include
- [ ] Other creation parameters (Port? EnablingAuthentication? FrameworkVersion?)
- [ ] Reintroduce launchsettings.json if useful
- [ ] Are there any references that can be pulled at creation time? Helm charts for example

## The template creation project

- [ ] Local building
- [ ] Tests
- [x] Installation and usage notes
- [x] Template packaging on all platforms ([.csproj package](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates#packing-a-template-into-a-nuget-package-nupkg-file))
- [x] Template package versioning
- [x] Removal of package warnings