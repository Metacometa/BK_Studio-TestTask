public class AuthScreen : BaseScreen
{
    public AuthScreen(UserContext userContext, ICommandRegistry commandRegistry, 
        IParser parser, IConsoleRenderer renderer) 
            : base(userContext, commandRegistry, parser, renderer) 
    {
    }

    public override void SendStartMessage()
    {
        userContext.Notification = new Notification(NotificationType.Info,
            "Добро пожаловать! \nДля работы требуется авторизация.");
    }

    public override void Show()
    {
        renderer.PrintHeader();
        Console.WriteLine();
        renderer.PrintNotification(userContext.Notification);

        Console.WriteLine("\nДоступные команды: ");
        Console.WriteLine();
        PrintCommands();

        Console.WriteLine();
        renderer.PrintEndLine();
        Console.Write("> ");
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
