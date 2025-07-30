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
            ? screenFactory.Create("registerScreen")
            : screenFactory.Create("authScreen");
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

            switch (role)
            {
                case Role.Employee:
                    screen = screenFactory.Create("emloyeeScreen");
                    break;
                case Role.Manager:
                    screen = screenFactory.Create("managerScreen");
                    break;
                default:
                    break;
           }
/*
            string key = role.ToString().ToLower();

            screen = screenFactory.Create(key);*/
        }
        catch (Exception ex)
        {
            userContext.Notification = $"Внутренняя ошибка: {ex.Message}";
        }
    }
}