public class AuthScreen : BaseScreen
{
    public AuthScreen(ICommandRegistry commandRegistry, IParser parser) : base(commandRegistry, parser) {}

    public override void Show()
    {
        Console.WriteLine("Auth screen");
        Console.WriteLine($"Command: {commands.Count}");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);
    }
}
