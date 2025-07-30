public class CreateUserCommand : ICommand
{
    private readonly IAuthService authService;
    private readonly IParser parser;

    public CreateUserCommand(IAuthService authService, IParser parser)
    {
        this.authService = authService;
        this.parser = parser;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 3)
        {
            throw new IndexOutOfRangeException("Ошибка ввода: неправильное количество аргументов");
        }

        if (parser.TryParseRole(args[2], out Role role))
        {
            authService.Register(args[0], args[1], role);
        }
        else
        {
            throw new ArgumentException($"Ошибка ввода: роли \"{args[2]}\" не существует");
        }
    }
}
