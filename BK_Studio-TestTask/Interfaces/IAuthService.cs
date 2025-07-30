public interface IAuthService
{
    public void Login(string user, string password);
    public User CreateUser(string username, string password, Role role);
    public void SetCurrentUser(User user);
    public void Logout();
}
