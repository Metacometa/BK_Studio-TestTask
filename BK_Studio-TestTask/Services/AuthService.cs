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
        userRepository.AddUser(userContext.User);
        Console.WriteLine("Login");
        userRepository.GetUsers();
        EventBus.Instance.TriggerAuthSuccessful();
    }
    
    public void Register(string username, string password, Role role)
    {
        User user = new User(username, password, role);
        Console.WriteLine(user);

        userRepository.AddUser(user);
        userContext.User = user;

        EventBus.Instance.TriggerAuthSuccessful();
    }
}
