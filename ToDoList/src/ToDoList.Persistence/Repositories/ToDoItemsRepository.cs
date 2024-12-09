namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public async Task<IEnumerable<ToDoItem>> ReadAllAsync()
    {
        return await context.ToDoItems.ToListAsync();
    }

    public async Task<ToDoItem?> ReadByIdAsync(int id)
    {
        return await context.ToDoItems.FindAsync(id);
    }

     public async Task UpdateAsync(ToDoItem item)
    {
        var foundItem = await context.ToDoItems.FindAsync(item.ToDoItemId) ?? throw new ArgumentOutOfRangeException($"ToDo item with ID {item.ToDoItemId} not found.");
        context.Entry(foundItem).CurrentValues.SetValues(item);
        await context.SaveChangesAsync();
    }
    public async Task DeleteAsync(ToDoItem item)
    {
        context.ToDoItems.Remove(item);
        await context.SaveChangesAsync();
    }

}
