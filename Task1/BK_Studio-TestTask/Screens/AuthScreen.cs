public class AuthScreen : BaseScreen
{
    public AuthScreen(IUserContext userContext, ICommandRegistry commandRegistry, 
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

        renderer.PrintNotification(userContext.Notification);

        renderer.PrintSubheader("Доступные команды");
        //Console.WriteLine("Доступные команды: ");
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
