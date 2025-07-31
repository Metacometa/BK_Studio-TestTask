public class AuthScreen : BaseScreen
{
    public AuthScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
    }

    public override void SendStartMessage()
    {
        userContext.Notification = "Добро пожаловать! \nДля работы требуется авторизация.";
    }

    public override void Show()
    {
        WriteHeader();
        Console.WriteLine();
        WriteNotification(userContext.Notification);

        Console.WriteLine("\nДоступные команды: ");
        Console.WriteLine();
        PrintCommands();

        Console.WriteLine();
        WriteEndLine();
        Console.Write("> ");
    }

    private void PrintCommands()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);

        for (int i = 0; i < commands.Count; i++)
        {
            Console.Write("  - ");
            WriteInstruction($"{commands[i].Prompt}");
        }
    }
}
