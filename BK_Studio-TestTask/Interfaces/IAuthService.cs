public interface IAuthService
{
    public void Login(string user, string password);
    public void Register(string username, string password, Role role)
    {

    }
}
