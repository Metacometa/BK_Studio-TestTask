public interface ICommandPrinter
{
    public string Description { get; }
    public string Prompt { get; }
    public void PrintHelp();
}
