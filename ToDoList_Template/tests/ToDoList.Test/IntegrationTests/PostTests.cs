namespace ToDoList.Test.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.DTOs;
using ToDoList.Persistence;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;

public class PostTests
{
    [Fact]
    public async Task Post_ValidRequest_ReturnsNewItem()
    {
        // Arrange
        var connectionString = "Data Source=../../../IntegrationTests/data/localdb_test.db";
        using var context = new ToDoItemsContext(connectionString);
        var repository = new ToDoItemsRepository(context);
        var controller = new ToDoItemsController(repository);
        var request = new ToDoItemCreateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false
        );

        // Act
        var result = await controller.Create(request);
        var resultResult = result.Result;

        // Assert
        var createdAtResult = Assert.IsType<CreatedAtActionResult>(resultResult);
        var value = createdAtResult.Value as ToDoItemGetResponseDto;
        Assert.NotNull(value);

        Assert.Equal(request.Description, value.Description);
        Assert.Equal(request.IsCompleted, value.IsCompleted);
        Assert.Equal(request.Name, value.Name);

        // Cleanup
        var createdItem = await context.ToDoItems.FindAsync(value.Id);
        if (createdItem != null)
        {
            context.ToDoItems.Remove(createdItem);
            await context.SaveChangesAsync();
        }
    }
}

