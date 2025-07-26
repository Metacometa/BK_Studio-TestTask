public class CommandHandler : ICommandHandler
{
    private readonly Dictionary<string, ICommand> commands;

    private IParser parser;

    public CommandHandler(IParser parser,
        Dictionary<string, ICommand> commands)
    {
        parser = parser ?? throw new ArgumentNullException(nameof(parser));
        this.commands = commands ?? throw new ArgumentNullException(nameof(commands));

        this.parser = parser;
    }

    public void Handle(string input)
    {
        var (command, args) = parser.ParseCommand(input);
    }
}
