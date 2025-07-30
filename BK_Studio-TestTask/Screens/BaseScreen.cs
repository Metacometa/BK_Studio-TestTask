public abstract class BaseScreen : IScreen
{
    protected readonly Dictionary<string, ICommand> commands;

    protected readonly IParser parser;

    protected readonly UserContext userContext;

    public BaseScreen(UserContext userContext, ICommandRegistry commandRegistry, IParser parser)
    {
        this.userContext = userContext;
        commands = commandRegistry.CreateCommands();
        this.parser = parser;
    }

    public abstract void Init();

    public abstract void Show();

    public virtual void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);

        try
        {
            if (commands.TryGetValue(command, out ICommand result))
            {
                result.Execute(args);
            }
            else
            {
                throw new KeyNotFoundException("Ошибка ввода: неверная команда");
            }
        }
        catch (Exception ex)
        {
            userContext.Notification = ex.Message;
        }
    }
}
