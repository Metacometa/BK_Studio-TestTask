public class ChangeTaskStatusPrinter : BasePrinter
{
    public ChangeTaskStatusPrinter(string Description, string Prompt, IConsoleRenderer renderer) 
        : base(Description, Prompt, renderer) {}

    public override void PrintHelp()
    {
        Console.WriteLine($"{Description}");

        Console.Write("    Статусы: ");
        renderer.PrintTaskStatuses();

        Console.WriteLine();

        Console.Write("    - ");
        renderer.PrintInstruction($"{Prompt}");
    }
}
