namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class DeleteTests
{
    [Fact]
    public void Delete_ValidId_ReturnsNoContent()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context: context, repository: null); // Docasny hack, nez z controlleru odstranime context.
        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();

        // Act
        var result = controller.DeleteById(toDoItem.ToDoItemId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Delete_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var controller = new ToDoItemsController(context, null); // Docasny hack, nez z controlleru odstranime context.
        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();

        // Act
        var invalidId = -1;
        var result = controller.DeleteById(invalidId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
