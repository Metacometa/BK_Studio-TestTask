public class AuthCommand : ICommand
{
    private readonly IAuthService authService;

    public AuthCommand(IAuthService authService)
    {
        this.authService = authService;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new IndexOutOfRangeException("Ошибка ввода: неправильное количество аргументов");
        }

        authService.Login(args[0], args[1]);
    }
}
