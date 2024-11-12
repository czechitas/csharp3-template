namespace ToDoList.Persistence.Repositories;

using System.Collections.Generic;
using ToDoList.Domain.Models;

public class ToDoItemsRepository : IRepository<ToDoItem>
{
    private readonly ToDoItemsContext context;

    public ToDoItemsRepository(ToDoItemsContext context)
    {
        this.context = context;
    }

    public void Create(ToDoItem item)
    {
        context.ToDoItems.Add(item);
        context.SaveChanges();
    }
    public IEnumerable<ToDoItem> ReadAll() => context.ToDoItems.ToList();
    public ToDoItem? ReadById(int id) => context.ToDoItems.Find(id);
    public void Update(ToDoItem item)
    {
        context.Entry(item).CurrentValues.SetValues(item);
        context.SaveChanges();
    }

    public void Delete(ToDoItem item)
    {
        context.ToDoItems.Remove(item);
        context.SaveChanges();
    }
}
