public class User
{
    public int Login { get; set; }
    public int Password {get; set; }

    public User(int login, int password)
    {
        Login = login;
        Password = password;    
    }
}
