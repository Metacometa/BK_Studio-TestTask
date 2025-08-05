using System.ComponentModel;

public class CreateTaskCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly ITaskService taskService;
    private readonly IParser parser;

    public CreateTaskCommand(ITaskService taskService, IParser parser, ICommandPrinter printer)
    {
        this.taskService = taskService;
        this.parser = parser;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length < 2)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        string description = string.Join(" ", args[2..]);

        taskService.CreateTask(args[0], args[1], description);
    }
}
