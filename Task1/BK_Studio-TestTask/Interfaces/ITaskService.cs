public interface ITaskService
{
    public void CreateTask(string name, string projectId, string description);
    public List<Task> GetTasks(User user);
    public void ChangeStatus(string name, TaskStatus status);
    public void AddExecutor(string name, string executor);
}
