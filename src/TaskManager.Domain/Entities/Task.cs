using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Task
{
    private Task(string title, string description, Status status)
    {
        Title = title;
        Description = description;
        Status = status;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }

    public static Task Create(
        string title,
        string description,
        Status status)
    {
        return new Task(title, description, status);
    }
}
