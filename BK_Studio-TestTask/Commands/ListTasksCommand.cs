using System.ComponentModel;

public class ListTasksCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IUserContextManager contextManager;

    public ListTasksCommand(IUserContextManager contextManager, ICommandPrinter printer)
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

        contextManager.GetTasks();
    }
}
