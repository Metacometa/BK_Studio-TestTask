using System.ComponentModel;

public abstract class BaseScreen : IScreen
{
    protected readonly IParser parser;
    protected readonly ICommandRegistry commandRegistry;
    protected readonly IConsoleRenderer renderer;

    protected readonly IUserContext userContext;

    public BaseScreen(IUserContext userContext, ICommandRegistry commandRegistry, IParser parser, IConsoleRenderer renderer)
    {
        this.userContext = userContext;
        this.parser = parser;
        this.commandRegistry = commandRegistry;
        this.renderer = renderer;
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
        catch (WarningException ex)
        {
            userContext.Notification = new Notification(NotificationType.Warning, ex.Message);
        }
        catch (Exception ex)
        {
            userContext.Notification = new Notification(NotificationType.Error, ex.Message);
        }
    }
}
