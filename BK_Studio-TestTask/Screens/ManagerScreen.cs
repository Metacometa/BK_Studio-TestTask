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

        Console.WriteLine($"\nЗдравствуйте, {userContext.User.Login}! Ваша роль: {userContext.User.Role}");
        Console.WriteLine($"Ваша роль: {userContext.User.Role}");
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
