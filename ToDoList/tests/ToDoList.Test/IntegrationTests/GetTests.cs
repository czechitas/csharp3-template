namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var context = new ToDoItemsContext("Data Source=../../../../../data/localdb.db");
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

        var toDoItem = new ToDoItem
        {
            Name = "Jmeno",
            Description = "Popis",
            IsCompleted = false
        };
        context.ToDoItems.Add(toDoItem);
        context.SaveChanges();

        // Act
        var result = controller.Read();
        var resultResult = result.Result;
        var value = result.GetValue();

        // Assert
        Assert.IsType<OkObjectResult>(resultResult);
        Assert.NotNull(value);

        var item = value.First(i => i.Id == toDoItem.ToDoItemId);
        Assert.NotNull(item);
        Assert.Equal(toDoItem.ToDoItemId, item.Id);
        Assert.Equal(toDoItem.Description, item.Description);
        Assert.Equal(toDoItem.IsCompleted, item.IsCompleted);
        Assert.Equal(toDoItem.Name, item.Name);
    }
}
