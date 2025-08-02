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
        renderer.PrintHeader();

        renderer.PrintNotification(userContext.Notification);
        Console.WriteLine("Доступные команды: ");
        Console.WriteLine();
        PrintCommands();

        Console.WriteLine();
        renderer.PrintEndLine();
        Console.Write("> ");


        //Console.WriteLine("=== Система управления проектом ===");

        //Console.WriteLine(userContext.Notification);

        //Console.WriteLine("\nКоманда для создания управляющего: register <логин> <пароль>");
    }

    private void PrintCommands()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);

        for (int i = 0; i < commands.Count; i++)
        {
            Console.Write("   - ");
            renderer.PrintInstruction($"{commands[i].Printer.Prompt}");
        }
    }
}
