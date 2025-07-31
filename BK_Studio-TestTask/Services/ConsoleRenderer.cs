public class ConsoleRenderer
{
    public static ConsoleRenderer instance = new ConsoleRenderer();

    private ConsoleColor instructionsColor = ConsoleColor.Yellow;
    private ConsoleColor frameColor = ConsoleColor.Cyan;
    private ConsoleColor headerColor = ConsoleColor.White;

    private ConsoleColor errorColor = ConsoleColor.Red;
    private ConsoleColor messageColor = ConsoleColor.Yellow;
    private ConsoleColor notificationColor = ConsoleColor.Gray;
    public void WriteHeader()
    {
        Console.ForegroundColor = instance.frameColor;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.Write("║      ");

        Console.ForegroundColor = instance.headerColor;
        Console.Write("СИСТЕМА УПРАВЛЕНИЯ ПРОЕКТОМ");

        Console.ForegroundColor = instance.frameColor;
        Console.WriteLine("     ║");
        Console.WriteLine("╚══════════════════════════════════════╝");

        Console.ResetColor();
    }

    public void WriteEndLine()
    {
        Console.ForegroundColor = instance.frameColor;
        Console.WriteLine("────────────────────────────────────────");
        Console.ResetColor();
    }

    public void WriteInstruction(string input)
    {
        Console.ForegroundColor = instance.instructionsColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    public void WriteNotification(string input)
    {
        Console.ForegroundColor = instance.notificationColor;
        Console.WriteLine(input);
        Console.ResetColor();
    }

    public void SetErrorNotificationColor()
    {
        instance.notificationColor = instance.errorColor;
    }

    public void SetMessageNotificationColor()
    {
        instance.notificationColor = instance.messageColor;
    }

}
