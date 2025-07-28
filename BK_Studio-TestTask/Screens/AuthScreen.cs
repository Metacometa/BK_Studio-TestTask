public class AuthScreen : BaseScreen
{
    public AuthScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
    }

    public override void Init()
    {
        userContext.Notification = "Добро пожаловать! Пожалуйста, авторизуйтесь:";
    }

    public override void Show()
    {
        Console.WriteLine("=== Система управления проектом ===");

        Console.WriteLine(userContext.Notification);

        Console.WriteLine("\nКоманда для входа: auth <логин> <пароль>");
    }

/*    public override void HandleInput()
    {
        string? input = Console.ReadLine();
        if (input == null) return;

        var (command, args) = parser.ParseCommand(input!);

        try
        {
            if (commands.TryGetValue(command, out ICommand result))
            {
                result.Execute(args);
            }
            else
            {
                throw new KeyNotFoundException("Ошибка ввода: неверная команда");
            }
        }
        catch (KeyNotFoundException ex)
        {
            userContext.Notification = ex.Message;
        }
        catch (IndexOutOfRangeException ex)
        {
            userContext.Notification = "Ошибка ввода: неправильное количество аргументов";
        }
    }*/
}
