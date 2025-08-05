using System.Text.Json;

public class TaskRepository : ITaskRepository
{
    private const string filePath = "tasks.json";
    private Dictionary<string, Task> tasks;
    public int Count => tasks.Count;

    public List<Task> Tasks
    { 
        get => new List<Task>(tasks.Values); 
    }

    public TaskRepository()
    {
        tasks = File.Exists(filePath)
            ? JsonSerializer.Deserialize<Dictionary<string, Task>>(File.ReadAllText(filePath))
                ?? new Dictionary<string, Task>()
            : new Dictionary<string, Task>();
    }

    public void AddTask(Task task)
    {
        if (tasks.ContainsKey(task.Name) == true)
        {
            throw new Exception($"[ОШИБКА]: Задача \"{task.Name}\" уже существует");
        }

        tasks.Add(task.Name, task);
        File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
    }

    public void UpdateTask(Task task)
    {
        if (tasks.ContainsKey(task.Name) == true)
        {
            tasks[task.Name] = task;
            File.WriteAllText(filePath, JsonSerializer.Serialize(tasks));
        }
        else
        {
            throw new Exception($"[ОШИБКА]: Несуществующая задача: \"{task.Name}\"");
        }    
    }

    public Task GetByName(string name)
    {
        if (tasks.TryGetValue(name, out Task result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"[ОШИБКА]: Задача \"{name}\" не найдена");
        }
    }

    public List<Task> GetByUsername(string username)
    {
        List<Task> tasks = new List<Task>();

        foreach (Task task in Tasks)
        {
            if (task.Executors.Contains(username))
            {
                tasks.Add(task);
            }
        }

        return tasks;
    }
}
