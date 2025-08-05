using System.ComponentModel;

public class AddExecutorCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly ITaskService taskService;
    private readonly IParser parser;

    public AddExecutorCommand(ITaskService taskService, IParser parser, ICommandPrinter printer)
    {
        this.taskService = taskService;
        this.parser = parser;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 2)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        taskService.AddExecutor(args[0], args[1]);
    }
}
