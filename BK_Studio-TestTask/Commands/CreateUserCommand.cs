public class CreateUserCommand : ICommand
{
    public string Description { get; private set; }
    public string Prompt { get; }

    private readonly IAuthService authService;
    private readonly IParser parser;

    public CreateUserCommand(IAuthService authService, IParser parser, string description, string prompt)
    {
        this.authService = authService;
        this.parser = parser;
        Description = description;
        Prompt = prompt;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 3)
        {;
            throw new IndexOutOfRangeException("[ОШИБКА]: Неправильное количество аргументов");
        }

        if (parser.TryParseRole(args[2], out Role role))
        {
            authService.CreateUser(args[0], args[1], role);
        }
        else
        {
            throw new ArgumentException($"[ОШИБКА]: Роли \"{args[2]}\" не существует");
        }
    }
}
