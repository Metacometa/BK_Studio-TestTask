public class ConsoleRenderer : IConsoleRenderer
{
    private readonly ConsoleTheme theme;
    private readonly IRolePrinter rolePrinter;
    private readonly INotificationPrinter notificationPrinter;

    public ConsoleRenderer(ConsoleTheme theme, IRolePrinter rolePrinter, INotificationPrinter notificationPrinter)
    {
        this.theme = theme;
        this.rolePrinter = rolePrinter;
        this.notificationPrinter = notificationPrinter;
    }

    public void PrintHeader()
    {
        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.Write("║      ");

        Console.ForegroundColor = theme.headerColor;
        Console.Write("СИСТЕМА УПРАВЛЕНИЯ ПРОЕКТОМ");

        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("     ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();
    }

    public void PrintEndLine()
    {
        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("────────────────────────────────────────");
        Console.ResetColor();
    }

    public void PrintInstruction(string input)
    {
        Console.ForegroundColor = theme.instructionColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    public void PrintNotification(Notification notification)
    {
        notificationPrinter.Print(notification);
    }

    public void PrintColorized(string input, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(input);
        Console.ResetColor();
    }

    public void PrintUserList(List<User> users, string currentLogin = "")
    {
        if (users.Count == 0 ) { return; }

        Console.WriteLine("Список сотрудников: ");
        Console.WriteLine();

        Dictionary<Role, List<User>> usersByRoles = SortUsersByRoles(users);
        PrintUsersByRoles(usersByRoles, currentLogin);
    }

    private void PrintUsersByRoles(Dictionary<Role, List<User>> usersByRoles,
        string currentLogin = "")
    {
        int rolesCounter = 1;
        foreach (var item in usersByRoles)
        {
            Role role = item.Key;

            Console.Write($"[{rolesCounter++}] Роль ");
            rolePrinter.PrintRole(role);
            Console.WriteLine(":");

            int loginCounter = 1;
            foreach (var user in item.Value)
            {
                Console.Write($"    {loginCounter++}. {user.Login}");
                if (user.Login == currentLogin)
                {
                    PrintColorized(" <- Вы", ConsoleColor.White);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        PrintEndLine();
        Console.WriteLine();
    }

    private Dictionary<Role, List<User>> SortUsersByRoles(List<User> users)
    {
        Dictionary<Role, List<User>> usersByRoles = new Dictionary<Role, List<User>>();

        foreach (User user in users)
        {
            if (!usersByRoles.TryGetValue(user.Role, out List<User> value))
            {
                usersByRoles[user.Role] = new List<User>();
            }

            usersByRoles[user.Role].Add(user);
        }

        return usersByRoles;
    }

    public void PrintRoles()
    {
        rolePrinter.PrintRoles();
    }
}
