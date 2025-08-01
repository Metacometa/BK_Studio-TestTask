using System.ComponentModel;

public class RegisterCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IAuthService authService;

    public RegisterCommand(IAuthService authService, ICommandPrinter printer)
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

        User user = authService.CreateUser(args[0], args[1], Role.Manager);
        authService.SetCurrentUser(user);
    }
}
