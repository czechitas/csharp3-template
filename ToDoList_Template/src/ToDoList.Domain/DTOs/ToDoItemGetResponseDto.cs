namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;

public record class ToDoItemGetResponseDto(int Id, string Name, string Description, bool IsCompleted) //let client know the Id
{
    public static ToDoItemGetResponseDto FromDomain(ToDoItem item) => new(item.ToDoItemId, item.Name, item.Description, item.IsCompleted);
}
