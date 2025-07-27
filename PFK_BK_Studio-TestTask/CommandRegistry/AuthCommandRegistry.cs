public class AuthCommandRegistry(CommandFactory commandFactory) : BaseCommandRegistry(commandFactory)
{
    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["auth"] = commandFactory.CreateTestCommand()
        };

        return commands;
    }
}
