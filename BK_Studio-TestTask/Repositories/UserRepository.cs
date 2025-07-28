using System.Text.Json;

public class UserRepository : IUserRepository
{
    private const string filePath = "users.json";
    private List<User> users;

    public UserRepository()
    {
        users = File.Exists(filePath)
            ? JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filePath)) ?? new List<User>()
            : new List<User>();
    }

    public void AddUser()
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(users));
    }
}
