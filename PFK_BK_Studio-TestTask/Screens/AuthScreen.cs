public class AuthScreen(ICommandRegistry commandRegistry, IParser parser) : BaseScreen(commandRegistry, parser)
{
    public override void Show()
    {
        Console.WriteLine("Auth screen");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);
    }
}
