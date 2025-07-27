public class BaseScreen : IScreen
{
    private readonly Dictionary<string, ICommand> commands;

    private readonly IParser parser;

    public BaseScreen(ICommandFactory commandFactory, IParser parser)
    {
        commands = commandFactory.CreateCommands();
        this.parser = parser;
    }

    public void Show()
    {
        Console.WriteLine("Base screen");
    }

    public void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);
    }
}
