public class FirstRegisterScreen : BaseScreen
{
    public FirstRegisterScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
    }

    public override void SendStartMessage()
    {
        userContext.Notification = "Первый старт! Создайте нового управляющего:";
    }

    public override void Show()
    {
        Console.WriteLine("=== Система управления проектом ===");

        Console.WriteLine(userContext.Notification);

        Console.WriteLine("\nКоманда для создания управляющего: register <логин> <пароль>");
    }
}
