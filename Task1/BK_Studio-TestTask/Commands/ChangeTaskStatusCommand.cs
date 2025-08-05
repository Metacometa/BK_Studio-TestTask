using System.ComponentModel;

public class ChangeTaskStatusCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly ITaskService taskService;
    private readonly IParser parser;

    public ChangeTaskStatusCommand(ITaskService taskService, IParser parser, ICommandPrinter printer)
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

        if (parser.TryParseTaskStatus(args[1], out TaskStatus status))
        {
            taskService.ChangeStatus(args[0], status);
        }
        else
        {
            throw new ArgumentException($"[ОШИБКА]: Статус \"{args[1]}\" некорректен");
        }
    }
}
