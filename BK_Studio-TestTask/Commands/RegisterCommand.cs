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

        authService.Register(args[0], args[1], Role.Manager);
    }
}
