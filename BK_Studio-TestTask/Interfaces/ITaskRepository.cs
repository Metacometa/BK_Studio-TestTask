public interface ITaskRepository
{
    public int Count { get; }
    public void AddUser(Task task);
    public Task GetByName(string username);
    //public List<Task> Tasks { get; }
}
