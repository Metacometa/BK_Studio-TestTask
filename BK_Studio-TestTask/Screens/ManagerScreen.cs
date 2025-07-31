public class ManagerScreen : BaseScreen
{
    public ManagerScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
        
    }

    public override void SendStartMessage()
    {
        userContext.Notification = $"Здравствуйте, {userContext.User.Login}!" + 
            $"\nВаша роль: {userContext.User.Role}";
    }

    public override void Show()
    {
        ConsoleRenderer.instance.WriteHeader();
        Console.WriteLine();
        ConsoleRenderer.instance.WriteNotification(userContext.Notification);

        Console.WriteLine($"\nДоступные действия:");
        Console.WriteLine();
        PrintCommands();

        ConsoleRenderer.instance.WriteEndLine();
        Console.Write($"> ");
    }

    private void PrintCommands()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);

        for (int i = 0; i < commands.Count; i++)
        {
            
            Console.Write($"{i + 1}. {commands[i].Printer.Description}");
            Console.Write("\n   Команда: ");
            ConsoleRenderer.instance.WriteInstruction($"{commands[i].Printer.Prompt}");

            Console.WriteLine();
        }
    }
}
