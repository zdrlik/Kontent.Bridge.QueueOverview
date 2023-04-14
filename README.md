# Kontent Message Queue Overview Architecture Startup 

![Architecture diagram](https://github.com/zdrlik/Kontent.Bridge.QueueOverview/blob/master/MessageOverview-API-architecture.png)

## 1. Kontent Message Queue Overview
The Kontent Message Queue Overview is a simple API that allows you to monitor the messages in the Kontent bridge message queue. 

## 2. Architecture
The project's architecture is based on the [Clean Architecture(https://github.com/jasontaylordev/CleanArchitecture)] principles. The solution consists of 5 projects:
* Kontent.Bridge.QueueOverview.Api - the API project
* Kontent.Bridge.QueueOverview.Application - the application layer
* Kontent.Bridge.QueueOverview.Domain - the domain layer
* Kontent.Bridge.QueueOverview.Infrastructure - the infrastructure layer
* Kontent.Bridge.QueueOverview.Application.Tests - the unit tests project for the application layer

## 3. Technologies
* .NET 7
* ASP.NET Core 7
* MediatR
* AutoMapper
* FluentValidation
* xUnit
* Moq
* Docker

