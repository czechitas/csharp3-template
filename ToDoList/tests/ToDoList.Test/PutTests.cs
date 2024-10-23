namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class PutTests
{
    [Fact]
    public void Put_ValidId_ReturnsNoContent()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var result = controller.UpdateById(toDoItem.ToDoItemId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Put_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem = new ToDoItem
        {
            ToDoItemId = 1,
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        controller.items.Add(toDoItem);

        var request = new ToDoItemUpdateRequestDto(
            Name: "Jine jmeno",
            Description: "Jiny popis",
            IsCompleted: true
        );

        // Act
        var invalidId = -1;
        var result = controller.UpdateById(invalidId, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
