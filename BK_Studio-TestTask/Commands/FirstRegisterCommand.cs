public class FirstRegisterCommand : ICommand
{
    private readonly IAuthService authService;

    public FirstRegisterCommand(IAuthService authService)
    {
        this.authService = authService;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new IndexOutOfRangeException();
        }

        authService.Register(args[0], args[1], Role.Manager);
    }
}
