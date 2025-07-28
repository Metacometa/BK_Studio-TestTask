public class ManagerCommandRegistry : BaseCommandRegistry
{
    public ManagerCommandRegistry(CommandFactory commandFactory) : base(commandFactory) {}

    public override Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            //["register"] = commandFactory.CreateAuthCommand()
        };

        return commands;
    }
}
