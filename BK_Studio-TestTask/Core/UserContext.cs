public class UserContext : IUserContext
{
    public User User { get; set; }

    public Notification Notification { get; set; }

    public List<User> UserList { get; set; }

    public UserContext()
    {
        User = new User();
        Notification = new Notification();
        UserList = new List<User>();

        EventBus.Instance.screenDisplayed += ClearData;
    }

    public void ClearData()
    {
        UserList = new List<User>();
    }
}
