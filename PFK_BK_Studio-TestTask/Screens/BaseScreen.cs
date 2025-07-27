public abstract class BaseScreen : IScreen
{
    protected readonly Dictionary<string, ICommand> commands;

    protected readonly IParser parser;

    public BaseScreen(ICommandRegistry commandRegistry, IParser parser)
    {
        commands = commandRegistry.CreateCommands();
        this.parser = parser;
    }

    public abstract void Show();

    public abstract void HandleInput();
}
