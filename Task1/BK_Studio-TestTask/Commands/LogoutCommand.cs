using System.ComponentModel;

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
        if (args.Length != 0)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        authService.Logout();
    }
}
