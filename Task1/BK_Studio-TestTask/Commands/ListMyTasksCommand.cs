using System.ComponentModel;

public class ListMyTasksCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IUserContextManager contextManager;
    private readonly IUserContext userContext;

    public ListMyTasksCommand(IUserContextManager contextManager, 
        IUserContext userContext,
        ICommandPrinter printer)
    {
        this.contextManager = contextManager;
        this.userContext = userContext;

        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 0)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        contextManager.GetTasksByUsername(userContext.User.Login);
    }
}
