namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public async Task Delete_DeleteByIdValidItemId_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        repositoryMock.ReadByIdAsync(1).Returns(Task.FromResult<ToDoItem?>(toDoItem));

        // Act
        var result = await controller.DeleteById(1);

        // Assert
        Assert.IsType<NoContentResult>(result);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.Received(1).DeleteByIdAsync(1);
    }

    [Fact]
    public async Task Delete_DeleteByIdInvalidItemId_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadByIdAsync(1).Returns(Task.FromResult<ToDoItem?>(null));

        // Act
        var result = await controller.DeleteById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.DidNotReceive().DeleteByIdAsync(Arg.Any<int>());
    }

    [Fact]
    public async Task Delete_DeleteByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        repositoryMock.ReadByIdAsync(Arg.Any<int>()).Returns(x => Task.FromException<ToDoItem?>(new Exception("Database error")));
        var controller = new ToDoItemsController(repositoryMock);

        // Act
        var result = await controller.DeleteById(1);
        var resultResult = result as ObjectResult;

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, resultResult?.StatusCode);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.DidNotReceive().DeleteByIdAsync(Arg.Any<int>());
    }
}

