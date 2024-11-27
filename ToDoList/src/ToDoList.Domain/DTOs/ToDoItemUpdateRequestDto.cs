namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public record class ToDoItemUpdateRequestDto(string Name, string Description, bool IsCompleted, string? Category)
{
    public ToDoItem ToDomain() => new() { Name = this.Name, Description = this.Description, IsCompleted = this.IsCompleted, Category = this.Category };
}
