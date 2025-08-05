using System.Text.Json;

public class UserRepository : IUserRepository
{
    private const string filePath = "users.json";
    private Dictionary<string, User> users;
    public int Count => users.Count;

    public List<User> Users
    {
        get => new List<User>(users.Values);
    }

    public UserRepository()
    {
        users = File.Exists(filePath)
            ? JsonSerializer.Deserialize<Dictionary<string, User>>(File.ReadAllText(filePath))
                ?? new Dictionary<string, User>()
            : new Dictionary<string, User>();
    }

    public void AddUser(User user)
    {
        if (users.ContainsKey(user.Login) == true)
        {
            throw new Exception($"[ОШИБКА]: Логин \"{user.Login}\" уже занят");
        }

        users.Add(user.Login, user);
        File.WriteAllText(filePath, JsonSerializer.Serialize(users));
    }

    public User GetByUsername(string username)
    {
        if (users.TryGetValue(username, out User result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"[ОШИБКА]: Пользователь с логином \"{username}\" не найден");
        }
    }
}
