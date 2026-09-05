namespace ToDoList.Models;

public class TaskList
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ?Description { get; set; }
    public bool Completed { get; set; } = false;
    public DateTime ?CreatedAt { get; set; }
    public DateTime ?UpdatedAt { get; set; }
    public bool Important { get; set; } = false;
}