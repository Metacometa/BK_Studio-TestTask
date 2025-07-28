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
            throw new IndexOutOfRangeException();
        }

        Console.WriteLine("(Execute)");

        authService.Login(args[0], args[1]);
    }
}
