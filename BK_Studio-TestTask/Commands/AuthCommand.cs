public class AuthCommand : ICommand
{
    public string Description { get; private set; }
    public string Prompt { get; }

    private readonly IAuthService authService;

    public AuthCommand(IAuthService authService, string description, string prompt)
    {
        this.authService = authService;
        Description = description;
        Prompt = prompt;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new IndexOutOfRangeException("[ОШИБКА]: Неправильное количество аргументов");
        }

        authService.Login(args[0], args[1]);
    }
}
