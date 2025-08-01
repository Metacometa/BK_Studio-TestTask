public class ManagerScreen : BaseScreen
{
    public ManagerScreen(UserContext userContext, ICommandRegistry commandRegistry, 
        IParser parser, IConsoleRenderer renderer) 
            : base(userContext, commandRegistry, parser, renderer) 
    {
        
    }

    public override void SendStartMessage()
    {
        userContext.Notification = new Notification(NotificationType.Info,
            $"Здравствуйте, {userContext.User.Login}!" +
            $"\nВаша роль: {userContext.User.Role}");
    }

    public override void Show()
    {
        renderer.PrintHeader();
        Console.WriteLine();
        renderer.PrintNotification(userContext.Notification);

        Console.WriteLine($"\nДоступные команды:");
        Console.WriteLine();
        PrintCommands();

        renderer.PrintEndLine();
        Console.Write($"> ");
    }

    private void PrintCommands()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);

        for (int i = 0; i < commands.Count; i++)
        {
            Console.Write($"[{i + 1}] ");
            commands[i].Printer.PrintHelp();
            //Console.Write("   - ");
            //renderer.PrintInstruction($"{commands[i].Printer.Prompt}");

            /*            Console.Write($"{i + 1}. {commands[i].Printer.Description}");
                        Console.Write("\n   Команда: ");
                        ConsoleRenderer.instance.PrintInstruction($"{commands[i].Printer.Prompt}");*/

            Console.WriteLine();
        }
    }
}
