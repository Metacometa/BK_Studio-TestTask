public abstract class BaseScreen : IScreen
{
    protected readonly IParser parser;
    protected readonly ICommandRegistry commandRegistry;

    protected readonly UserContext userContext;

    public BaseScreen(UserContext userContext, ICommandRegistry commandRegistry, IParser parser)
    {
        this.userContext = userContext;
        this.parser = parser;
        this.commandRegistry = commandRegistry;

        EventBus.Instance.error += ConsoleRenderer.instance.SetErrorNotificationColor;
        EventBus.Instance.newMessage += ConsoleRenderer.instance.SetMessageNotificationColor;
    }

    public abstract void SendStartMessage();
    public abstract void Show();
    public virtual void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (name, args) = parser.ParseCommand(input!);

        try
        {
            ICommand command = commandRegistry.GetCommand(name, userContext.User.Role);
            command.Execute(args);
            EventBus.Instance.TriggerNewMessage();
        }
        catch (Exception ex)
        {
            EventBus.Instance.TriggerError();
            userContext.Notification = ex.Message;
        }
    }
}
