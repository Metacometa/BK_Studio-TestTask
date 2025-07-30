public class AuthScreen : BaseScreen
{
    public AuthScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
    }

    public override void Init()
    {
        userContext.Notification = "Добро пожаловать! \nДля работы требуется авторизация.";
    }

    public override void Show()
    {
        WriteHeader();
        Console.WriteLine();
        WriteNotification(userContext.Notification);
        Console.Write("\nДоступные команды: ");
        WriteInstruction("\n  - auth <логин> <пароль>");
        WriteEndLine(); 

        Console.Write("Введите команду: ");
    }
}
