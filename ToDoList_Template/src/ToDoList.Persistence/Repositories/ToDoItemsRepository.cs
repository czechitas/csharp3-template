namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepositoryAsync<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(ToDoItem item)
    {
        await context.ToDoItems.AddAsync(item);
        await context.SaveChangesAsync();
    }
    public async Task<IEnumerable<ToDoItem>> ReadAllAsync() => await context.ToDoItems.ToListAsync();
    public async Task<ToDoItem?> ReadByIdAsync(int id) => await context.ToDoItems.FindAsync(id);
    public async Task UpdateAsync(ToDoItem item)
    {
        var foundItem = await context.ToDoItems.FindAsync(item.ToDoItemId) ?? throw new ArgumentOutOfRangeException($"ToDo item with ID {item.ToDoItemId} not found.");
        context.Entry(foundItem).CurrentValues.SetValues(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var item = await context.ToDoItems.FindAsync(id) ?? throw new ArgumentOutOfRangeException($"ToDo item with ID {id} not found.");
        context.ToDoItems.Remove(item);
        await context.SaveChangesAsync();
    }
}
