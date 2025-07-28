public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;

    private IUserContext userContext;

    public AuthService(IUserContext userContext, IUserRepository userRepository)
    {
        this.userContext = userContext;
        this.userRepository = userRepository;
    }

    public void Login(string username, string password)
    {

        Console.WriteLine("Login");
        EventBus.Instance.TriggerUserAuth();
    }
}
