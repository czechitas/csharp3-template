namespace ToDoList.Test.IntegrationTests;

using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var connectionString = "Data Source=../../../IntegrationTests/data/localdb_test.db";
        using var context = new ToDoItemsContext(connectionString);
        var controller = new ToDoItemsController(context: context, repository: null);;

        var todoItem1 = new ToDoItem
        {
            Name = "Jmeno1",
            Description = "Popis1",
            IsCompleted = false
        };
        var todoItem2 = new ToDoItem
        {
            Name = "Jmeno2",
            Description = "Popis2",
            IsCompleted = true
        };

        context.ToDoItems.Add(todoItem1);
        context.ToDoItems.Add(todoItem2);
        context.SaveChanges();

        // Act
        var result = controller.Read();
        var value = result.GetValue();

        // Assert
        Assert.NotNull(value);

        var firstToDo = value.First();
        Assert.Equal(todoItem1.ToDoItemId, firstToDo.Id);
        Assert.Equal(todoItem1.Name, firstToDo.Name);
        Assert.Equal(todoItem1.Description, firstToDo.Description);
        Assert.Equal(todoItem1.IsCompleted, firstToDo.IsCompleted);

        // Cleanup
        context.ToDoItems.Remove(todoItem1);
        context.ToDoItems.Remove(todoItem2);
        context.SaveChanges();
    }
}

