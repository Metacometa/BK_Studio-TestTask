public class AuthCommandRegistry : BaseCommandRegistry
{
    public AuthCommandRegistry(CommandFactory commandFactory) : base(commandFactory) {}

    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["auth"] = commandFactory.CreateTestCommand()
        };

        return commands;
    }
}
