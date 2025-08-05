public enum NotificationType
{
    Error, Info, Success, Welcome, Warning, None
}

public class Notification
{
    public NotificationType Type { get; set; }
    public string Text { get; set; }

    public Notification()
    {
        Type = NotificationType.None;
        Text = string.Empty;
    }

    public Notification(NotificationType type, string text)
    {
        Type = type;
        Text = text;
    }
}
