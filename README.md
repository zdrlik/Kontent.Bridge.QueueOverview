# Kontent Message Queue Overview Architecture Startup 

![Architecture diagram](https://github.com/zdrlik/Kontent.Bridge.QueueOverview/blob/master/MessageOverview-API-architecture.png)
Note: arrows represents compile-time dependencies. 

## 1. Kontent Message Queue Overview
The Kontent Message Queue Overview is a simple API that allows you to monitor the messages in the Kontent bridge message queue. 

## 2. Architecture
The project's architecture is based on the [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) principles. The solution consists of 5 projects:
* Kontent.Bridge.QueueOverview.Api - the API project
* Kontent.Bridge.QueueOverview.Application - the application layer
* Kontent.Bridge.QueueOverview.Domain - the domain layer
* Kontent.Bridge.QueueOverview.Infrastructure - the infrastructure layer
* Kontent.Bridge.QueueOverview.Application.Tests - the unit tests project for the application layer

![Project dependency diagram](https://github.com/zdrlik/Kontent.Bridge.QueueOverview/blob/master/Project%20dependency%20diagram.png)

### Kontent.Bridge.QueueOverview.Domain
This project typically contains all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Kontent.Bridge.QueueOverview.Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. 
This layer defines interfaces that are implemented by outside layers. 
For example, if the application need to access a repository, a repository interface would be added to application and an implementation would be created within infrastructure.

### Kontent.Bridge.QueueOverview.Domain
This layer typically contains classes for accessing external resources such databases, other services etc. 
These classes should be based on interfaces defined within the application layer.

### Kontent.Bridge.QueueOverview.API
This layer is a ASP.NET Core Web API project. It is responsible for exposing the API endpoints and handling the HTTP requests.
Request processing is delegated to the application layer through the use of MediatR.

### Kontent.Bridge.QueueOverview.Application.Tests
This project contains unit tests for the application layer. It is dependent on the application layer and the domain layer.


## 3. Technologies
* [ASP.NET Core 7](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [xUnit](https://xunit.net/)
* [Moq](https://github.com/moq/moq)

