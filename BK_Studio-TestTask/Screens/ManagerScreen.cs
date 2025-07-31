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
        WriteHeader();
        Console.WriteLine();
        WriteNotification(userContext.Notification);

        Console.WriteLine($"\nДоступные действия:");
        Console.WriteLine();
        PrintCommands();

        WriteEndLine();
        Console.Write($"> ");
    }

    private void PrintCommands()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);

        for (int i = 0; i < commands.Count; i++)
        {
            Console.Write($"{i + 1}. {commands[i].Description}");
            Console.Write("\n   Команда: ");
            WriteInstruction($"{commands[i].Prompt}");

            Console.WriteLine();
        }
    }

    private string RolesToString()
    {
        string roles = string.Empty;

        foreach (Role role in Enum.GetValues(typeof(Role)))
        {
            if (role == Role.Unathorized) continue;
            roles += role.ToString() + ", ";
        }

        roles = roles.Substring(0, roles.Length - 2);

        return roles;
    }
}
