public class BasePrinter : ICommandPrinter
{
    public string Description { get; }
    public string Prompt { get; }
    protected IConsoleRenderer renderer;

    public BasePrinter(string Description, string Prompt, IConsoleRenderer renderer)
    {
        this.Description = Description;
        this.Prompt = Prompt;

        this.renderer = renderer;
    }

    public virtual void PrintHelp()
    {
        Console.WriteLine($"{Description}");

        Console.Write("    - ");
        renderer.PrintInstruction($"{Prompt}");
    }
}
