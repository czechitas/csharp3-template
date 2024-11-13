namespace ToDoList.Domain.DTOs;

using ToDoList.Domain.Models;

public record ToDoItemCreateRequestDto(string Name, string Description, bool IsCompleted) //id is generated
{
    public ToDoItem ToDomain() => new() { Name = Name, Description = Description, IsCompleted = IsCompleted };
}
