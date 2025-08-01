public class FirstRegisterScreen : BaseScreen
{
    public FirstRegisterScreen(IUserContext userContext, ICommandRegistry commandRegistry, 
        IParser parser, IConsoleRenderer renderer) 
        : base(userContext, commandRegistry, parser, renderer) 
    {
    }

    public override void SendStartMessage()
    {
        userContext.Notification = new Notification(NotificationType.Info,
            "Первый старт! Создайте нового управляющего:");
    }

    public override void Show()
    {
        Console.WriteLine("=== Система управления проектом ===");

        Console.WriteLine(userContext.Notification);

        Console.WriteLine("\nКоманда для создания управляющего: register <логин> <пароль>");
    }
}
