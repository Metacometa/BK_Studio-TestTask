public class NotificationPrinter : INotificationPrinter
{
    private readonly ConsoleTheme theme;

    public NotificationPrinter(ConsoleTheme theme)
    {
        this.theme = theme;
    }

    public void Print(Notification notification)
    {
        ConsoleColor color = GetNotificationColor(notification);

        if (notification.Text != string.Empty)
        {
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.Write(notification.Text);
            Console.ResetColor();

            Console.WriteLine("\n");
        }
    }

    private ConsoleColor GetNotificationColor(Notification notification)
    {
        switch (notification.Type)
        {
            case NotificationType.Info:
                return theme.infoColor;
            case NotificationType.Error:
                return theme.errorColor;
            case NotificationType.Success:
                return theme.successColor;
            case NotificationType.Welcome:
                return theme.welcomeColor;
            case NotificationType.Warning:
                return theme.warningColor;
            default:
                return ConsoleColor.Gray;
        }
    }
}
