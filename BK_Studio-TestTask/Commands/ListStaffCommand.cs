using System.ComponentModel;

public class ListStaffCommand : ICommand
{
    public ICommandPrinter Printer { get; }

    private readonly IDataService dataService;

    public ListStaffCommand(IDataService dataService, ICommandPrinter printer)
    {
        this.dataService = dataService;
        Printer = printer;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 0)
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неправильное количество аргументов");
        }

        dataService.GetUsers();
    }
}
