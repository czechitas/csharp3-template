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
    public async Task Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        var existingItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        repositoryMock.ReadByIdAsync(1).Returns(Task.FromResult<ToDoItem?>(existingItem));

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = await controller.UpdateById(1, request);

        // Assert
        Assert.IsType<NoContentResult>(result);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.Received(1).UpdateAsync(Arg.Is<ToDoItem>(x => 
            x.ToDoItemId == 1 && 
            x.Name == "Jine jmeno" && 
            x.Description == "Jiny popis" && 
            x.IsCompleted == true));
    }

    [Fact]
    public async Task Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);

        repositoryMock.ReadByIdAsync(1).Returns(Task.FromResult<ToDoItem?>(null));

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = await controller.UpdateById(1, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.DidNotReceive().UpdateAsync(Arg.Any<ToDoItem>());
    }

    [Fact]
    public async Task Put_UpdateByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        repositoryMock.ReadByIdAsync(Arg.Any<int>()).Returns(x => Task.FromException<ToDoItem?>(new Exception("Database error")));
        var controller = new ToDoItemsController(repositoryMock);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = await controller.UpdateById(1, request);
        var resultResult = result as ObjectResult;

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, resultResult?.StatusCode);

        await repositoryMock.Received(1).ReadByIdAsync(1);
        await repositoryMock.DidNotReceive().UpdateAsync(Arg.Any<ToDoItem>());
    }
}

