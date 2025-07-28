public class Application
{
    private readonly UserContext userContext;
    private readonly ScreenFactory screenFactory;

    private readonly IUserRepository userRepository;
    private IScreen screen;

    public Application(UserContext userContext, IUserRepository userRepository, ScreenFactory screenFactory)
    {
        this.userContext = userContext;
        this.screenFactory = screenFactory;

        this.userRepository = userRepository;

        EventBus.Instance.authSuccessful += SetMenuScreen;

        screen = userRepository.Count == 0
            ? screenFactory.Create("register")
            : screenFactory.Create("auth");
        /*        screen = userRepository.Count == 0
                    ? screenFactory.CreateFirstStartScreen()
                    : screenFactory.CreateAuthScreen();*/
    }

    public void StartWorking()
    {
        while (true)
        {
            //Console.Clear();
            screen.Show();
            screen.HandleInput();
        }
    }

    public void SetMenuScreen()
    {
        try
        {
            Role role = userContext.User.Role;
            string key = role.ToString().ToLower();

            screen = screenFactory.Create(key);
            //screen = screenFactory.CreateMenuScreen();
        }
        catch (Exception ex)
        {
            userContext.Notification = $"Внутренняя ошибка: {ex.Message}";
        }
    }
}