public class CreateUserPrinter : BasePrinter
{
    public CreateUserPrinter(string Description, string Prompt, IConsoleRenderer renderer) 
        : base(Description, Prompt, renderer) {}

    public override void PrintHelp()
    {
        Console.WriteLine($"{Description}");

        Console.Write("    Роли: ");
        renderer.PrintRoles();

        Console.WriteLine();
        Console.WriteLine();

        Console.Write("    - ");
        renderer.PrintInstruction($"{Prompt}");
    }
}
