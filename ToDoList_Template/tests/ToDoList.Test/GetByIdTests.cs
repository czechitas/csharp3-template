namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;

public class GetByIdTests
{
    [Fact]
    public void GetById_ValidId_ReturnsItem()
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

        // Act
        var result = controller.ReadById(toDoItem.ToDoItemId);
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);

        Assert.Equal(toDoItem.ToDoItemId, value.Id);
        Assert.Equal(toDoItem.Description, value.Description);
        Assert.Equal(toDoItem.IsCompleted, value.IsCompleted);
        Assert.Equal(toDoItem.Name, value.Name);
    }

    [Fact]
    public void GetById_InvalidId_ReturnsNotFound()
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

        // Act
        var invalidId = -1;
        var result = controller.ReadById(invalidId);
        var resultResult = result.Result;

        // Assert
        Assert.IsType<NotFoundResult>(resultResult);
    }
}
