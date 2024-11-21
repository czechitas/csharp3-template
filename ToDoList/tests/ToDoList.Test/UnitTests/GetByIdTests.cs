namespace ToDoList.Test.UnitTests;

using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using ToDoList.Persistence.Repositories;
using ToDoList.Domain.Models;
using Microsoft.AspNetCore.Http;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

public class GetByIdUnitTests
{
    [Fact]
    public async Task Get_ReadByIdWhenSomeItemAvailable_ReturnsOk()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
       repositoryMock.ReadByIdAsync(someId).Returns(new ToDoItem { Name = "testItem", Description = "testDescription", IsCompleted = false });

        // Act
        var result = await controller.ReadByIdAsync(someId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
       await repositoryMock.Received(1).ReadByIdAsync(someId);
    }

    [Fact]
    public async Task Get_ReadByIdWhenItemIsNull_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
        repositoryMock.ReadByIdAsync(someId).ReturnsNull();

        // Act
        var result = await controller.ReadByIdAsync(someId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
       await repositoryMock.Received(1).ReadByIdAsync(someId);
    }

    [Fact]
    public async Task Get_ReadByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var someId = 1;
        repositoryMock.ReadByIdAsync(someId).Throws(new Exception());

        // Act
        var result =await controller.ReadByIdAsync(someId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<ObjectResult>(resultResult);
       await repositoryMock.Received(1).ReadByIdAsync(someId);
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status500InternalServerError), resultResult);
    }

}
