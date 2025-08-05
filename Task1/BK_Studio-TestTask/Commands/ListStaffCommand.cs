using System.ComponentModel;

public class ListStaffCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IUserContextManager contextManager;

    public ListStaffCommand(IUserContextManager contextManager, ICommandPrinter printer)
    {
        this.contextManager = contextManager;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 0)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        contextManager.GetUsers();
    }
}
