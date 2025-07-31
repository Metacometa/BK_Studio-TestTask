public class ChangeStatusCommand : ICommand
{
    public string Description { get; private set; }
    public string Prompt { get; }

    private readonly IAuthService authService;
    private readonly IParser parser;

    public ChangeStatusCommand(IAuthService authService, IParser parser, string description, string prompt)
    {
        this.authService = authService;
        this.parser = parser;
        Description = description;
        Prompt = prompt;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 3)
        {
            throw new IndexOutOfRangeException("[ОШИБКА]: Неправильное количество аргументов");
        }

        if (parser.TryParseRole(args[2], out Role role))
        {

        }
        else
        {
            throw new ArgumentException($"Placeholder");
        }
    }
}
