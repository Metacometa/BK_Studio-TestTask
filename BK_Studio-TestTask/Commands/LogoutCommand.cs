public class LogoutCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IAuthService authService;

    public LogoutCommand(IAuthService authService, ICommandPrinter printer)
    {
        this.authService = authService;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
       authService.Logout();
    }
}
