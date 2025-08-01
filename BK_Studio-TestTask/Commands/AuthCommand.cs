using System.ComponentModel;

public class AuthCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IAuthService authService;

    public AuthCommand(IAuthService authService, ICommandPrinter printer)
    {
        this.authService = authService;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        authService.Login(args[0], args[1]);
    }
}
