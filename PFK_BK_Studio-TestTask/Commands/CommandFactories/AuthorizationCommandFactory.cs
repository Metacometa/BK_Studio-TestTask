public class AuthorizationCommandFactory : ICommandFactory
{
    public Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["test"] = new TestCommand()
        };

        return commands;
    }
}
