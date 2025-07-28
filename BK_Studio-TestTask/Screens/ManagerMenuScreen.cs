public class ManagerMenuScreen : BaseScreen
{
    public ManagerMenuScreen(IUserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) {}

    public override void Show()
    {
        Console.Clear();
        Console.WriteLine("Экран менеджера");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);
        Console.WriteLine($"Command: {command}");
        foreach (var arg in args) Console.WriteLine(arg);
    }
}
