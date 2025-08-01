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

        Console.ForegroundColor = color;
        Console.WriteLine(notification.Text);
        Console.ResetColor();
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
            default:
                return ConsoleColor.Gray;
        }
    }
}
