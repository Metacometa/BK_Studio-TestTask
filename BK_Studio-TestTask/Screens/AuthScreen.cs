public class AuthScreen : BaseScreen
{
    public AuthScreen(IUserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) {}

    public override void Show()
    {
        Console.WriteLine("ЭКРАН АВТОРИЗАЦИИ");
        Console.WriteLine("Введите: auth \"Login\" \"Password\"");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);

        try
        {
            commands[command].Execute(args);
            Console.WriteLine("Execute->");
        }
        catch (KeyNotFoundException ex)
        {
            Console.Clear();
            Console.WriteLine($"Ошибка: неверная команда");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.Clear();
            Console.WriteLine($"Ошибка: неправильные количество аргументов");
        }


/*        Console.WriteLine($"Command: {command}");
        foreach (var arg in args) Console.WriteLine(arg);*/
    }
}
