using System.ComponentModel;

public class ChangeStatusCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IAuthService authService;
    private readonly IParser parser;

    public ChangeStatusCommand(IAuthService authService, IParser parser, ICommandPrinter printer)
    {
        this.authService = authService;
        this.parser = parser;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 3)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        if (parser.TryParseRole(args[2], out Role role))
        {

        }
        else
        {
            throw new ArgumentException($"Placeholder");
        }
    }
}
