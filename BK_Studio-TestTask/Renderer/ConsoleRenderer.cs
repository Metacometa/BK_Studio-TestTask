public class ConsoleRenderer : IConsoleRenderer
{
    private readonly ConsoleTheme theme;
    private readonly IRolePrinter rolePrinter;
    private readonly INotificationPrinter notificationPrinter;
    private readonly ITaskPrinter taskPrinter;

    public ConsoleRenderer(ConsoleTheme theme, IRolePrinter rolePrinter, 
        INotificationPrinter notificationPrinter, ITaskPrinter taskPrinter)
    {
        this.theme = theme;

        this.rolePrinter = rolePrinter;
        this.notificationPrinter = notificationPrinter;
        this.taskPrinter = taskPrinter;
    }

    public void PrintHeader()
    {
        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("╔═══════════════════════════════════════╗");
        Console.WriteLine("║                                       ║");
        Console.Write("║      ");

        Console.ForegroundColor = theme.headerColor;
        Console.Write("СИСТЕМА УПРАВЛЕНИЯ ПРОЕКТОМ");

        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("      ║");
        Console.WriteLine("║                                       ║");
        Console.WriteLine("╚═══════════════════════════════════════╝");

        Console.ResetColor();
    }

    public void PrintSubheader(string input)
    {
        string topFrame = "╔═══════════════════════════════════════╗";
        int topFramgeLength = topFrame.Length;

        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine(topFrame);
        Console.Write("║ ");

        Console.ForegroundColor = theme.headerColor;
        Console.Write($"{input}");

        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine(new string(' ', topFramgeLength - input.Length - 3) + "║");
        Console.WriteLine("╚═══════════════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();
    }

    public void PrintSeparator()
    {
        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("────────────────────────────────────────");
        Console.ResetColor();
    }

    public void PrintEndLine()
    {
        Console.ForegroundColor = theme.frameColor;
        Console.WriteLine("═════════════════════════════════════════");
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

        PrintSubheader("Список сотрудников");

        Dictionary<Role, List<User>> usersByRoles = Utilities.SortUsersByRoles(users);
        PrintUsersByRoles(usersByRoles, currentLogin);
    }

    public void PrintTaskList(List<Task> tasks)
    {   
        if (tasks.Count == 0) { return; }

        PrintSubheader("Список задач");

        for (int i = 0; i < tasks.Count; ++i)
        {
            Task task = tasks[i];
            Console.Write($"[{i + 1}] ");

            taskPrinter.PrintTask(task);

            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public void PrintMyTaskList(List<Task> tasks)
    {
        if (tasks.Count == 0) { return; }

        PrintSubheader("Список ваших задач");
        for (int i = 0; i < tasks.Count; ++i)
        {
            Task task = tasks[i];
            Console.Write($"[{i + 1}] ");

            taskPrinter.PrintTask(task);

            Console.WriteLine();
            Console.WriteLine();
        }
    }


    public void PrintCommands(List<ICommand> commands)
    {
        if (commands.Count == 0) { return; }

        PrintSubheader("Доступные команды");
        //Console.WriteLine($"Доступные команды:");

        for (int i = 0; i < commands.Count; i++)
        {
            Console.Write($"[{i + 1}] ");
            commands[i].Printer.PrintHelp();
            Console.WriteLine();
        }
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
    }

    public void PrintRoles()
    {
        rolePrinter.PrintRoles();
    }
}
