public class UserContext
{
    public User User { get; set; }
    public string Notification { get; set; } = string.Empty;

    public UserContext()
    {
        User = new User(string.Empty, string.Empty, Role.Unathorized);
    }
}
