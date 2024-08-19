# Net 8 Core Skeleton v1.0.0

## Technologies used

- .NET 8.0
- ASP.NET Core
- C# 12.0
- Swagger
- API Versioning
- BCrypt.Net
- Mapster
- Novell.Directory.Ldap
- Serilog
- Sieve
- Stylecop

## Getting Started

### Develop

To start developing your application, just use the .Net CLI command:

```bash
 > dotnet run Garuda.Host.csproj
```

> You can just type `dotnet run` in the project directory or configure your IDE to run.
> In this last case just don't forget to pass the `ASPNETCORE_ENVIRONMENT=Development` environment variable.

This will also run all node dependencies like `npm i`.

> The application will be started in _Development_ mode with hot reloading
> enabled at `https://localhost:5001` and `http://localhost:5000`.
> you can change the url port on src/Host/Properties/launchSettings.json

To add migration

```bash
> dotnet ef migrations add <NAME>
```

To update database
```bash
> dotnet ef database update
``` 

### Publishing
Simply use the normal way of publishing using .Net Core CLI

```bash
> dotnet publish YourProject.csproj -c release -o ./publish/
```

> You can also add all the other parameter from the dotnet cli.
> Please [visit the MSDN site](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=net5) to know more about it.

### Requirements

- JetBrains Rider 2023.3.4 or later
- Visual Studio 2022

# Structure Folder
```
├── src
│   ├── Auth
│   │   ├── Garuda.Auth.Abstract
│   │   └── Garuda.Auth.Ldap
│   ├── Core
│   │   ├── Application
│   │   │   └── Garuda.Application.Common
│   │   │       ├── Actions
│   │   │       ├── Dto
│   │   │       │   ├── Request
│   │   │       │   └── Response
│   │   │       ├── Mapper
│   │   │       ├── Middleware
│   │   │       ├── Services
│   │   │       │   └── V1
│   │   │       │       └── Contracts
│   │   │       └── Sieves
│   │   ├── Domain
│   │   │   └── Garuda.Domain.Common
│   │   │       ├── Models
│   │   │       └── Seeds
│   │   └── Repository
│   │       └── Garuda.Repository.Common
│   │           ├── Constants
│   │           ├── Helper
│   │           └── Repositories
│   │               └── Contracts
│   ├── Database
│   │   ├── Garuda.Database.Abstract
│   │   ├── Garuda.Database.Framework
│   │   ├── Garuda.Database.HRITM
│   │   ├── Garuda.Database.MsSql
│   │   ├── Garuda.Persistences.Abstract
│   │   │   ├── Actions
│   │   │   └── Contracts
│   │   ├── Garuda.Persistences.Framework
│   │   │   ├── Actions
│   │   │   ├── Extensions
│   │   │   └── Models
│   │   │       └── Audits
│   │   │           └── Configs
│   │   └── Garuda.Persistences.MsSql
│   │       └── Actions
│   ├── Extension
│   │   └── Garuda.Extension
│   │       ├── Contracts
│   │       └── Extensions
│   ├── Host
│   │   ├── Actions
│   │   ├── Migrations
│   │   ├── Properties
│   │   │   └── launchSettings.json
│   │   ├── README.md
│   │   ├── appsettings.json
│   │   └── appsettings.json.sample
│   ├── Modules
│   │   ├── Garuda.Modules.Common
│   │   └── Garuda.Presentation.Common
│   │       ├── Actions
│   │       ├── Controllers
│   │       │   └── V1
│   │       └── Middleware
│   ├── Providers
│   │   └── Auth
│   │       ├── Garuda.Providers.Auth.Abstract
│   │       │   ├── Action
│   │       │   ├── Contract
│   │       │   └── Dto
│   │       └── Garuda.Providers.Auth.Ldap
│   │           ├── Actions
│   │           ├── Configurations
│   │           ├── Constants
│   │           │   └── Error
│   │           └── Services
│   ├── Utilities
│   │   └── Garuda.Utilities
│   │       ├── Actions
│   │       ├── Configurations
│   │       ├── Constants
│   │       │   └── Error
│   │       ├── Contracts
│   │       ├── Dtos
│   │       │   └── Response
│   │       ├── Enums
│   │       ├── Events
│   │       ├── Exceptions
│   │       ├── Helpers
│   │       ├── Middleware
│   │       ├── Models
│   │       └── Sieves
│   └── test
│       └── Modules
│           └── Garuda.Module.CommonTest
│               └── Services
│                   └── V1
├── stylecop.json
└── test
    ├── Core
    │   ├── Application
    │   │   └── Garuda.Application.Common.Test
    │   │       └── Services
    │   │           └── V1
    │   ├── Domain
    │   └── Repositories
    │       └── Garuda.Repository.Common.Test
    │           └── Repositories
    ├── Presentation
    └── Providers
```

## Providers

Collection Provider external libraries.

### Auth

this is a collection for external Auth Libraries.

#### Abstract

This is an abstract library which likely contains base classes or interfaces that define standard methods and properties related to authentication providers. This could include methods for signing in, signing out, resetting passwords, etc.

#### Ldap

This is an LDAP authentication provider. It probably includes implementations for the abstract methods and properties defined in Garuda.Providers.Auth.Abstract, but specific to LDAP (Lightweight Directory Access Protocol) authentication.

### FileStorages

this is a collection for external File Storage Libraries providers.

### Mails

this is a collection for external Mails providers.

## Core

this folder contains application, domain and repositories.

### Application

this is a collection for services.

### Domain

this is a collection for model entity.

### Repositories

this is a collection for repository model.

## Persistences

this is a collection for database.

## Presentation

this is a collection for api/controllers.

## Utilities

this is a collection for utilities / helper.