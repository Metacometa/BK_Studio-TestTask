using System.Text.Json;

public class TaskRepository : ITaskRepository
{
    private const string filePath = "tasks.json";
    private Dictionary<string, Task> tasks;

    public int Count { get; }

    public TaskRepository()
    {
        tasks = File.Exists(filePath)
            ? JsonSerializer.Deserialize<Dictionary<string, Task>>(File.ReadAllText(filePath))
                ?? new Dictionary<string, Task>()
            : new Dictionary<string, Task>();
    }

    public void AddUser(Task task)
    {

    }

    public Task GetByName(string username)
    {
        return null;
    }
}
