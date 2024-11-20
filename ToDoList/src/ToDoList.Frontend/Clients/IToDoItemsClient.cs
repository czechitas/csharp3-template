namespace ToDoList.Frontend.Clients;
using ToDoList.Frontend.Views;

public interface IToDoItemsClient
{
    public List<ToDoItemView> ReadItems();
}
