public interface ICommandFactory
{
    public Dictionary<string, ICommand> CreateCommands();
}