# SimpleWebAPI

Simple Web API for a solution demonstrating an in-memory database as well as MemoryCache usage.

Swashbuckle/Swagger allows us to test the application from a simple interface it generates for us out of the box.

## MemoryCache

We are consulting with MemoryCache for all operations and return from MemoryCache if what we are looking for exists there before forwarding a request to the InMemory Database.

If it isn't in Cache for whatever reason we will pull the results from the Database and then update the Cache for the future and send back the results.

## Unit Testing

The Unit tests in the project are specifically looking at the Validation classes for testing Create/Update/Delete.

Moq is used to setup the `IPersonService` to check to see if a `PersonExists` and to simulate the expectations from the database call.

## Third Party Libraries

- FluentAssertions

- FluentValidation
- FluentValidation.DependencyInjection

- MediatR
- MediatR.Extensions.Autofac.DependencyInjection
- MediatR.Extensions.FluentValidation.AspNetCore

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.Relational

- Microsoft.NET.Test.Sdk

- Moq

- MSTests.TestAdapter
- MSTests.TestFramework

- Swashbuckle.AspNetCore
