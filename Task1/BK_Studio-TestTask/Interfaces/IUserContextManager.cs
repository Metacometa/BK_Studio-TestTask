public interface IUserContextManager
{
    public void GetUsers();
    public void GetTasks();
    public void GetTasksByUsername(string username);
}
