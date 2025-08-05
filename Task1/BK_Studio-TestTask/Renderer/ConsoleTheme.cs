public class ConsoleTheme
{
    public ConsoleColor instructionColor = ConsoleColor.Yellow;
    public ConsoleColor frameColor = ConsoleColor.Cyan;
    public ConsoleColor headerColor = ConsoleColor.White;

    public ConsoleColor toDoColor = ConsoleColor.Yellow;
    public ConsoleColor inProgressColor = ConsoleColor.DarkCyan;
    public ConsoleColor doneColor = ConsoleColor.Green;

    public ConsoleColor executorColor = ConsoleColor.White;
    public ConsoleColor taskColor = ConsoleColor.Cyan;

    public ConsoleColor loginColor = ConsoleColor.White;

    public ConsoleColor errorColor = ConsoleColor.Red;
    public ConsoleColor successColor = ConsoleColor.Green;
    public ConsoleColor infoColor = ConsoleColor.White;
    public ConsoleColor welcomeColor = ConsoleColor.Cyan;
    public ConsoleColor warningColor = ConsoleColor.DarkYellow;

    public ConsoleColor managerColor = ConsoleColor.DarkCyan;
    public ConsoleColor employeeColor = ConsoleColor.DarkYellow;

    public Dictionary<NotificationType, ConsoleColor> notificationColors = new()
    {
        { NotificationType.Info, ConsoleColor.Gray },
        { NotificationType.Error, ConsoleColor.Red },
        { NotificationType.Success, ConsoleColor.Green }
    };
}
