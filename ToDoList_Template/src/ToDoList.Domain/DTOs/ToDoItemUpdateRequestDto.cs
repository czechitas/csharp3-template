namespace ToDoList.Domain.DTOs;

public record ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted)
{

}
