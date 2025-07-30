public class CommandRegistry : BaseCommandRegistry
{
    public CommandRegistry(CommandFactory commandFactory) : base(commandFactory) {}

    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["auth"] = commandFactory.AuthCommand()
        };

        return commands;
    }
}
