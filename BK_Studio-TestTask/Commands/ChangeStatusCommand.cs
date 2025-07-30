public class ChangeStatusCommand : ICommand
{
    private readonly IAuthService authService;
    private readonly IParser parser;

    public ChangeStatusCommand(IAuthService authService, IParser parser)
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

        }
        else
        {
            throw new ArgumentException($"Ошибка ввода: роли \"{args[2]}\" не существует");
        }
    }
}
