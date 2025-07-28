public abstract class BaseScreen : IScreen
{
    protected readonly Dictionary<string, ICommand> commands;

    protected readonly IParser parser;

    protected readonly IUserContext userContext;

    public BaseScreen(IUserContext userContext, ICommandRegistry commandRegistry, IParser parser)
    {
        this.userContext = userContext;
        commands = commandRegistry.CreateCommands();
        this.parser = parser;
    }

    public abstract void Show();

    public abstract void HandleInput();
}
