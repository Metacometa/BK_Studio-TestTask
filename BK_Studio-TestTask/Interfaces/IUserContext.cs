public interface IUserContext
{
    public User User { get; set; }
    public Notification Notification { get; set; }
    public List<User> UserList { get; set; }

    public void ClearData();
}
