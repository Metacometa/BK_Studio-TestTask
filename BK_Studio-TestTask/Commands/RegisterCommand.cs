public class RegisterCommand : ICommand
{
    private readonly IAuthService authService;

    public RegisterCommand(IAuthService authService)
    {
        this.authService = authService;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new IndexOutOfRangeException("Ошибка ввода: неправильное количество аргументов");
        }

        User user = authService.CreateUser(args[0], args[1], Role.Manager);
        authService.SetCurrentUser(user);
    }
}
