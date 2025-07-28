public interface IUserRepository
{
    public int Count { get; }
    public void AddUser(User user);
    public void GetUsers();
}
