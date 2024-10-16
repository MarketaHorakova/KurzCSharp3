namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public class ToDoItemGetResponseDto
{
    public int ToDoItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public static ToDoItemGetResponseDto FromDomain(ToDoItem item)
    {
        return new ToDoItemGetResponseDto
        {
            Name = item.Name,
            Description = item.Description,
            IsCompleted = item.IsCompleted,
        };
    }
}
