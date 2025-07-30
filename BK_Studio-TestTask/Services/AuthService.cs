public class AuthService : IAuthService
{
    private readonly UserContext userContext;
    private readonly IUserRepository userRepository;

    public AuthService(UserContext userContext, IUserRepository userRepository)
    {
        this.userContext = userContext;
        this.userRepository = userRepository;
    }

    public void Login(string username, string password)
    {
        User user = userRepository.GetByUsername(username);

        userContext.User = user;
    
        if (user.Password != password)
        {

            throw new UnauthorizedAccessException("Ошибка ввода: неверный пароль");
        }

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

        userContext.Notification = $"Пользователь \"{username}\" с ролью \"{role}\" был создан";
        return user;
    }

    public void SetCurrentUser(User user)
    {
        userContext.User = user;
        EventBus.Instance.TriggerAuthSuccessful();
    }
}
