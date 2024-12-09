namespace ToDoList.Frontend.Views;
using System.ComponentModel.DataAnnotations;
public class ToDoItemView
{
    public int ToDoItemId { get; set; }
    [Required(ErrorMessage = "Name is mandatory.")]
    [Length(3, 50)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "Description is mandatory.")]
    [StringLength(250)]
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }
    [StringLength(250)]
    public string? Category { get; set; }
}
