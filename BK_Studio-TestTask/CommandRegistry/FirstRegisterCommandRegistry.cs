public class FirstRegisterCommandRegistry : BaseCommandRegistry
{
    public FirstRegisterCommandRegistry(CommandFactory commandFactory) : base(commandFactory) {}

    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["register"] = commandFactory.CreateFirstRegisterCommand()
        };

        return commands;
    }
}
