using System.Data;

public class TaskService : ITaskService
{
    private readonly IUserContext userContext;
    private readonly ITaskRepository taskRepository;
    private readonly IUserRepository userRepository;

    public TaskService(UserContext userContext, ITaskRepository taskRepository, IUserRepository userRepository)
    {
        this.userContext = userContext;
        this.taskRepository = taskRepository;
        this.userRepository = userRepository;
    }

    public void CreateTask(string name, string projectId, string description)
    {
        int id = taskRepository.Count;
        int parsedProjectId = 0;

        try
        {
            parsedProjectId = int.Parse(projectId);
        }
        catch (Exception ex)
        {
            throw new Exception("[ОШИБКА]: Некорректный project id");
        }

        Task task = new Task(id, int.Parse(projectId), 
            name, description);

        taskRepository.AddTask(task);

        userContext.Notification = new Notification(NotificationType.Success,
            $"[УСПЕШНО]: Задача \"{task.Name}\" была создана");
    }

    public List<Task> GetTasks(User user)
    {
        return null;
    }

    public void ChangeStatus(string name)
    {

    }

    public void AddExecutor(string name, string executor)
    {
        Task task = taskRepository.GetByName(name);
        User user = userRepository.GetByUsername(executor);

        task.AddExecutor(user.Login);
        taskRepository.UpdateTask(task);

        userContext.Notification = new Notification(NotificationType.Success,
            $"[УСПЕШНО]: Пользователь \"{user.Login}\" назначен на задачу \"{task.Name}\"");
    }
}
