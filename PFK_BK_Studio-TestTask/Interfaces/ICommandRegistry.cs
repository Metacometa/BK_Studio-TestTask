public interface ICommandRegistry
{
    public Dictionary<string, ICommand> CreateCommands();
}