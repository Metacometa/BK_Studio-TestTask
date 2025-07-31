public class RegisterCommand : ICommand
{
    public string Description { get; private set; }
    public string Prompt { get; }

    private readonly IAuthService authService;

    public RegisterCommand(IAuthService authService, string description, string prompt)
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

        User user = authService.CreateUser(args[0], args[1], Role.Manager);
        authService.SetCurrentUser(user);
    }
}
