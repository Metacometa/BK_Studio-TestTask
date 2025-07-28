public enum Role
{
    Manager, Employee, Unathorized
}

public class User
{
    public string Login { get; set; }
    public string Password {get; set; }

    public Role Role { get; set; }

    public User(string login, string password, Role role)
    {
        Login = login;
        Password = password;
        Role = role;
    }
}
