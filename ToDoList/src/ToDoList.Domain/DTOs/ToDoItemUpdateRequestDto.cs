namespace ToDoList.Domain.DTOs;


public class ToDoItemUpdateRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

}
