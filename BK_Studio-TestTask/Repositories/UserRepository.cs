using System.Text.Json;

public class UserRepository : IUserRepository
{
    private const string filePath = "users.json";
    private List<User> users;

    public int Count => users.Count;

    public UserRepository()
    {
        users = File.Exists(filePath)
            ? JsonSerializer.Deserialize<List<User>>(File.ReadAllText(filePath)) ?? new List<User>()
            : new List<User>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
        File.WriteAllText(filePath, JsonSerializer.Serialize(users));
    }

    public void GetUsers()
    {
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
