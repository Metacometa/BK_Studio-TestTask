public class ConsoleTheme
{
    public ConsoleColor instructionColor = ConsoleColor.Yellow;
    public ConsoleColor frameColor = ConsoleColor.Cyan;
    public ConsoleColor headerColor = ConsoleColor.White;

    public ConsoleColor loginColor = ConsoleColor.White;

    public ConsoleColor errorColor = ConsoleColor.Red;
    public ConsoleColor successColor = ConsoleColor.Green;
    public ConsoleColor infoColor = ConsoleColor.Cyan;
    public ConsoleColor welcomeColor = ConsoleColor.Cyan;

    public ConsoleColor managerColor = ConsoleColor.DarkCyan;
    public ConsoleColor employeeColor = ConsoleColor.DarkYellow;

    public Dictionary<NotificationType, ConsoleColor> notificationColors = new()
    {
        { NotificationType.Info, ConsoleColor.Gray },
        { NotificationType.Error, ConsoleColor.Red },
        { NotificationType.Success, ConsoleColor.Green }
    };
}
