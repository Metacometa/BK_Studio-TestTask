public class UserContext
{
    public User User { get; set; }
    public string Notification { get; set; }

    public UserContext()
    {
        User = new User();
        Notification = string.Empty;
    }
}
