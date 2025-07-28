public class Application
{
    private readonly ScreenFactory screenFactory;
    private IScreen screen;

    public Application(ScreenFactory screenFactory)
    {
        this.screenFactory = screenFactory;
        screen = screenFactory.CreateAuthScreen();

        EventBus.Instance.UserAuth += SetManagerMenuScreen;
    }

    public void StartWorking()
    {
        while (true)
        {
            screen.Show();
            screen.HandleInput();
        }
    }

    public void SetManagerMenuScreen()
    {
        screen = screenFactory.CreateManagerMenuScreen();
    }
}