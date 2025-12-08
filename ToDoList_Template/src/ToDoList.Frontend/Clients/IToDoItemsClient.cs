namespace ToDoList.Frontend.Clients;

using ToDoList.Frontend.Models;

public interface IToDoItemsClient
{
    public Task<List<ToDoItemView>> ReadItemsAsync();
    public Task<ToDoItemView?> ReadItemByIdAsync(int itemId);
    public Task UpdateItemAsync(ToDoItemView item);
    public Task DeleteItemAsync(ToDoItemView itemView);
}
