public class ManagerScreen : BaseScreen
{
    public ManagerScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
        
    }

    public override void Init()
    {
        userContext.Notification = "Аутентификация прошла успешно";
    }

    public override void Show()
    {
        Console.WriteLine("=== Система управления проектом ===");

        Console.WriteLine(userContext.Notification);

        Console.WriteLine($"\nЗдравствуйте, {userContext.User.Login}!");
        Console.WriteLine($"Ваша роль: {userContext.User.Role}");

        Console.WriteLine($"\nДоступные вам действия:");
        Console.WriteLine($"1. Зарегистрировать нового пользователя");
        Console.WriteLine($"Команда: register");
        Console.WriteLine($"2. Создать новую задачу:");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);
        Console.WriteLine($"Command: {command}");
        foreach (var arg in args) Console.WriteLine(arg);
    }
}
