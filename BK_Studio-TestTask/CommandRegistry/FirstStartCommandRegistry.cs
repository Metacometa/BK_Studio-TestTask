public class FirstStartCommandRegistry : BaseCommandRegistry
{
    public FirstStartCommandRegistry(CommandFactory commandFactory) : base(commandFactory) {}

    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["register"] = commandFactory.CreateFirstRegisterCommand()
        };

        return commands;
    }
}
