namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetByIdTests
{
    [Fact]
    public void Get_ReadByIdWhenSomeItemAvailable_ReturnsOk()
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
        var result = controller.ReadById(1);
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);
        Assert.Equal(toDoItem.ToDoItemId, value.Id);
        Assert.Equal(toDoItem.Name, value.Name);
        Assert.Equal(toDoItem.Description, value.Description);
        Assert.Equal(toDoItem.IsCompleted, value.IsCompleted);

        repositoryMock.Received(1).ReadById(1);
    }

    [Fact]
    public void Get_ReadByIdWhenItemIsNull_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadById(Arg.Any<int>()).Returns((ToDoItem?)null);

        // Act
        var result = controller.ReadById(1);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);

        repositoryMock.Received(1).ReadById(1);
    }

    [Fact]
    public void Get_ReadByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        repositoryMock.ReadById(Arg.Any<int>()).Returns(x => throw new Exception("Database error"));
        var controller = new ToDoItemsController(repositoryMock);

        // Act
        var result = controller.ReadById(1);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<ObjectResult>(resultResult);
        var objectResult = resultResult as ObjectResult;
        Assert.Equal(500, objectResult?.StatusCode);

        repositoryMock.Received(1).ReadById(1);
    }
}

