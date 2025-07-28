public class FirstRegisterScreen : BaseScreen
{
    public FirstRegisterScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
    }

    public override void Init()
    {
        userContext.Notification = "Первый старт! Создайте нового управляющего:";
    }

    public override void Show()
    {
        Console.WriteLine("=== Система управления проектом ===");

        Console.WriteLine(userContext.Notification);

        Console.WriteLine("\nКоманда для создания управляющего: register <логин> <пароль>");
    }

/*    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);

        try
        {
            commands[command].Execute(args);
        }
        catch (KeyNotFoundException ex)
        {
            userContext.Notification = "Ошибка ввода: неверная команда";
        }
        catch (IndexOutOfRangeException ex)
        {
            userContext.Notification = "Ошибка ввода: неправильное количество аргументов";
        }
    }*/
}
