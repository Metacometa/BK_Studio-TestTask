using System.ComponentModel;

public class Application
{
    private readonly IUserContext userContext;
    private readonly ScreenFactory screenFactory;

    private readonly IUserRepository userRepository;
    private IScreen screen;

    public Application(IUserContext userContext, IUserRepository userRepository, ScreenFactory screenFactory)
    {
        this.userContext = userContext;
        this.screenFactory = screenFactory;

        this.userRepository = userRepository;

        EventBus.Instance.authSuccessful += SetMenuScreen;
        EventBus.Instance.logout += SetAuthScreen;

        screen = userRepository.Count == 0
            ? screenFactory.Create(ScreenType.FirstRegister)
            : screenFactory.Create(ScreenType.Auth);
    }

    public void StartWorking()
    {
        while (true)
        {
            Console.Clear();
            screen.Show();
            screen.HandleInput();
        }
    }

    private void SetMenuScreen()
    {
        try
        {
            Role role = userContext.User.Role;
            screen = screenFactory.CreateForRole(role);
        }
        catch (WarningException ex)
        {
            userContext.Notification = new Notification(NotificationType.Warning, ex.Message);
        }
        catch (Exception ex)
        {
            userContext.Notification = new Notification(NotificationType.Error, ex.Message);
        }
    }

    private void SetAuthScreen()
    {
        screen = screenFactory.Create(ScreenType.Auth);
    }
}