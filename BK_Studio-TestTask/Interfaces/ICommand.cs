public interface ICommand
{
    public string Description { get; }
    public string Prompt { get; }
    public abstract void Execute(string[] args);
}
