public class CreateUserCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IAuthService authService;
    private readonly IParser parser;

    public CreateUserCommand(IAuthService authService, IParser parser, ICommandPrinter printer)
    {
        this.authService = authService;
        this.parser = parser;
        Printer = printer;
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
