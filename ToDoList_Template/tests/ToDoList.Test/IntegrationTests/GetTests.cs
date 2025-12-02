namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class GetTests
{
    [Fact]
    public async Task Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var connectionString = "Data Source=../../../IntegrationTests/data/localdb_test.db";
        using var context = new ToDoItemsContext(connectionString);
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);

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

        await context.ToDoItems.AddAsync(todoItem1);
        await context.ToDoItems.AddAsync(todoItem2);
        await context.SaveChangesAsync();

        // Act
        var result = await controller.Read();
        var resultResult = result.Result;

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(resultResult);
        var value = okResult.Value as IEnumerable<ToDoItemGetResponseDto>;
        Assert.NotNull(value);

        var firstToDo = value.FirstOrDefault(x => x.Name == todoItem1.Name);
        Assert.NotNull(firstToDo);
        Assert.Equal(todoItem1.Name, firstToDo.Name);
        Assert.Equal(todoItem1.Description, firstToDo.Description);
        Assert.Equal(todoItem1.IsCompleted, firstToDo.IsCompleted);
        
        // Verify the item was actually saved with an ID
        Assert.True(firstToDo.Id > 0);

        // Cleanup
        context.ToDoItems.Remove(todoItem1);
        context.ToDoItems.Remove(todoItem2);
        await context.SaveChangesAsync();
    }
}

