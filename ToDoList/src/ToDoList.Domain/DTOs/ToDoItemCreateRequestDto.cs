namespace ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

public class ToDoItemCreateRequestDto(string Name, string Description, bool IsCompleted) //id is generated
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public ToDoItem ToDomain()
    {
        return new ToDoItem
        {
            Name = this.Name,
            Description = this.Description,
            IsCompleted = this.IsCompleted,
        };
    }
}
