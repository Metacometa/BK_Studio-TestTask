public class LogoutCommand : ICommand
{
    private readonly IAuthService authService;

    public LogoutCommand(IAuthService authService)
    {
        this.authService = authService;
    }

    public void Execute(string[] args)
    {
       authService.Logout();
    }
}
