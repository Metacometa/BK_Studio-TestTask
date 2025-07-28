public class RegisterCommand : ICommand
{
    private readonly IAuthService authService;

    public RegisterCommand(IAuthService authService)
    {
        this.authService = authService;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 3)
        {
            throw new IndexOutOfRangeException();
        }

        //authService.Register(args[0], args[1], Role.Manager);
    }
}
