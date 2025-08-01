public class UserContext
{
    public User User { get; set; }

    public Notification Notification { get; set; }

    public UserContext()
    {
        User = new User();
        Notification = new Notification();
    }
}
