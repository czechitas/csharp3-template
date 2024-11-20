namespace ToDoList.Frontend.Clients;

using ToDoList.Domain.DTOs;
using ToDoList.Frontend.Views;

public class ToDoItemsClient(HttpClient httpClient) : IToDoItemsClient
{
    public List<ToDoItemView> ReadItems()
    {
        var toDoItemsView = new List<ToDoItemView>();
        var response = httpClient.GetFromJsonAsync<List<ToDoItemGetResponseDto>>("api/ToDoItems");

        toDoItemsView = response.Result.Select(dto => new ToDoItemView
        {
            ToDoItemId = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        }).ToList();

        return toDoItemsView;
    }
}
