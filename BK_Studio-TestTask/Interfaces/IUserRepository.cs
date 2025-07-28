public interface IUserRepository
{
    public int Count { get; }
    public void AddUser(User user);
    public User GetByUsername(string username);
    public void GetUsers();
}
