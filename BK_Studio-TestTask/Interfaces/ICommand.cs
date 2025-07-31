public interface ICommand
{
    public ICommandPrinter Printer { get; }
    public abstract void Execute(string[] args);
}
