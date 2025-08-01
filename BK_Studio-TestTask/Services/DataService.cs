public class DataService : IDataService
{
    private readonly IUserContext userContext;
    private readonly IUserRepository userRepository;

    public DataService(IUserContext userContext, IUserRepository userRepository)
    {
        this.userContext = userContext;
        this.userRepository = userRepository;
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

    public void Login(string username, string password)
    {
        User user = userRepository.GetByUsername(username);
    
        if (user.Password != password)
        {

            throw new UnauthorizedAccessException("[ОШИБКА]: Неверный пароль");
        }

        userContext.User = user;

        EventBus.Instance.TriggerAuthSuccessful();
    }

    public void Logout()
    {
        userContext.User = new User();
        EventBus.Instance.TriggerLogout();
    }

    public User CreateUser(string username, string password, Role role)
    {
        User user = new User(username, password, role);
        userRepository.AddUser(user);

        userContext.Notification = new Notification(NotificationType.Success,
            $"[УСПЕШНО]: Пользователь \"{username}\" с ролью \"{role}\" был создан");

        return user;
    }

    public void SetCurrentUser(User user)
    {
        userContext.User = user;
        EventBus.Instance.TriggerAuthSuccessful();
    }
}
