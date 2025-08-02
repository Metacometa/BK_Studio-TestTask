using System.Threading.Tasks;

public class UserContextManager : IUserContextManager
{
    private readonly IUserContext userContext;
    private readonly IUserRepository userRepository;
    private readonly ITaskRepository taskRepository;

    public UserContextManager(IUserContext userContext, ITaskRepository taskRepository, IUserRepository userRepository)
    {
        this.userContext = userContext;

        this.userRepository = userRepository;
        this.taskRepository = taskRepository;
    }

    public void GetUsers()
    {
        List<User> users = userRepository.Users;

        if (users.Count == 0)
        {
            userContext.Notification = new Notification(NotificationType.Info, "Список сотрудников пуст");
        }
        else
        {
            userContext.Notification = new Notification(NotificationType.Info, "");
            userContext.UserList = users;
        }
    }

    public void GetTasks()
    {
        List<Task> tasks = taskRepository.Tasks;

        if (tasks.Count == 0)
        {
            userContext.Notification = new Notification(NotificationType.Info, "Список задач пуст");
        }
        else
        {
            userContext.Notification = new Notification(NotificationType.Info, "");
            userContext.TaskList = tasks;
        }
    }

    public void GetTasksByUsername(string username)
    {
        List<Task> tasks = taskRepository.GetByUsername(username);

        if (tasks.Count == 0)
        {
            userContext.Notification = new Notification(NotificationType.Info, "Ваш список задач пуст");
        }
        else
        {
            userContext.Notification = new Notification(NotificationType.Info, "");
            userContext.MyTaskList = tasks;
        }
    }
}
