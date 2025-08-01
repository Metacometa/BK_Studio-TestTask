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
        Console.WriteLine(input);
        Console.ResetColor();
    }

    public void PrintRoles()
    {
        rolePrinter.PrintRoles();
    }
}
