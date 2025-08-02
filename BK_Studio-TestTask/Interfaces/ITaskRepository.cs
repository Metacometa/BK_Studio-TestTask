public interface ITaskRepository
{
    public int Count { get; }
    public void AddTask(Task task);
    public void UpdateTask(Task task);
    public Task GetByName(string name);
    public List<Task> GetByUsername(string username);
    public List<Task> Tasks { get; }
}
