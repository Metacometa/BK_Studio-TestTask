public abstract class BaseCommandRegistry : ICommandRegistry
{
    protected readonly CommandFactory commandFactory;

    public BaseCommandRegistry(CommandFactory commandFactory)
    {
        this.commandFactory = commandFactory;
    }

    public abstract Dictionary<string, ICommand> CreateCommands();
}
