public enum TaskStatus
{
    ToDo, InProgress, Done
}

public class Task
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }

    public TaskStatus TaskStatus { get; set; }

    public Task()
    {
        ProjectId = 0;
        Name = string.Empty;
        Description = string.Empty;
        TaskStatus = TaskStatus.ToDo;
    }

    public Task(int id, int projectId, string name, string description)
    {
        Id = id;
        ProjectId = projectId;
        Name = name;
        Description = description;
        TaskStatus = TaskStatus.ToDo;
    }
}
