namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PutTests
{
    [Fact]
    public void Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var existingItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        repositoryMock.ReadById(1).Returns(existingItem);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = controller.UpdateById(1, request);

        // Assert
        Assert.IsType<NoContentResult>(result);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.Received(1).Update(Arg.Is<ToDoItem>(x => 
            x.ToDoItemId == 1 && 
            x.Name == "Jine jmeno" && 
            x.Description == "Jiny popis" && 
            x.IsCompleted == true));
    }

    [Fact]
    public void Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadById(1).Returns((ToDoItem?)null);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = controller.UpdateById(1, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.DidNotReceive().Update(Arg.Any<ToDoItem>());
    }

    [Fact]
    public void Put_UpdateByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        repositoryMock.ReadById(Arg.Any<int>()).Returns(x => throw new Exception("Database error"));
        var controller = new ToDoItemsController(repositoryMock);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = controller.UpdateById(1, request);
        var resultResult = result as ObjectResult;

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, resultResult?.StatusCode);

        repositoryMock.Received(1).ReadById(1);
        repositoryMock.DidNotReceive().Update(Arg.Any<ToDoItem>());
    }
}

