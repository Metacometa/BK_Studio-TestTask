public class CommandPrinter : ICommandPrinter
{
    public string Description { get; }
    public string Prompt { get; }

    public CommandPrinter(string Description, string Prompt)
    {
        this.Description = Description;
        this.Prompt = Prompt;
    }

    public void Print()
    {

    }
}
