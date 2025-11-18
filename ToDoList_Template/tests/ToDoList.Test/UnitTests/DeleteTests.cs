namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_DeleteByIdValidItemId_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        repositoryMock.ReadById(1).Returns(toDoItem);

        // Act
        var result = controller.DeleteById(1);

        // Assert
        Assert.IsType<NoContentResult>(result);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.Received(1).DeleteById(1);
    }

    [Fact]
    public void Delete_DeleteByIdInvalidItemId_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadById(1).Returns((ToDoItem?)null);

        // Act
        var result = controller.DeleteById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.DidNotReceive().DeleteById(Arg.Any<int>());
    }

    [Fact]
    public void Delete_DeleteByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        repositoryMock.ReadById(Arg.Any<int>()).Returns(x => throw new Exception("Database error"));
        var controller = new ToDoItemsController(repositoryMock);

        // Act
        var result = controller.DeleteById(1);
        var resultResult = result as ObjectResult;

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, resultResult?.StatusCode);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.DidNotReceive().DeleteById(Arg.Any<int>());
    }
}

