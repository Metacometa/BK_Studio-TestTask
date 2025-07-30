public abstract class BaseScreen : IScreen
{
    protected readonly IParser parser;
    protected readonly ICommandRegistry commandRegistry;

    protected readonly UserContext userContext;

    private ConsoleColor instructionsColor = ConsoleColor.Yellow;
    private ConsoleColor frameColor = ConsoleColor.Cyan;
    private ConsoleColor headerColor = ConsoleColor.White;

    private ConsoleColor errorColor = ConsoleColor.Red;
    private ConsoleColor messageColor = ConsoleColor.Yellow;
    private ConsoleColor notificationColor = ConsoleColor.Gray;

    public BaseScreen(UserContext userContext, ICommandRegistry commandRegistry, IParser parser)
    {
        this.userContext = userContext;
        this.parser = parser;
        this.commandRegistry = commandRegistry;

        EventBus.Instance.error += SetErrorNotificationColor;
        EventBus.Instance.newMessage += SetMessageNotificationColor;
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

    protected virtual void WriteHeader()
    {
        Console.ForegroundColor = frameColor;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.Write("║      ");
        Console.ForegroundColor = headerColor;
        Console.Write("СИСТЕМА УПРАВЛЕНИЯ ПРОЕКТОМ");
        Console.ForegroundColor = frameColor;
        Console.WriteLine("     ║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
    }

    protected virtual void WriteEndLine()
    {
        Console.ForegroundColor = frameColor;
        Console.WriteLine("\n────────────────────────────────────────");
        Console.ResetColor();
    }

    protected virtual void WriteInstruction(string input)
    {
        Console.ForegroundColor = instructionsColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    protected virtual void WriteNotification(string input)
    {
        Console.ForegroundColor = notificationColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    protected virtual void SetErrorNotificationColor()
    {
        notificationColor = errorColor;
    }

    protected virtual void SetMessageNotificationColor()
    {
        notificationColor = messageColor;
    }
}
