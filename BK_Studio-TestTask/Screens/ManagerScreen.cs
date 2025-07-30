public class ManagerScreen : BaseScreen
{
    public ManagerScreen(UserContext userContext, 
        ICommandRegistry commandRegistry, 
        IParser parser) : base(userContext, commandRegistry, parser) 
    {
        
    }

    public override void SendStartMessage()
    {
        userContext.Notification = $"Здравствуйте, {userContext.User.Login}!" + 
            $"\nВаша роль: {userContext.User.Role}";
    }

    public override void Show()
    {
        WriteHeader();
        Console.WriteLine();
        WriteNotification(userContext.Notification);

        Console.WriteLine($"\nДоступные действия:");
        Console.WriteLine($"1. Зарегистрировать нового пользователя");
        Console.WriteLine($"        Доступные роли: {RolesToString()}");
        Console.WriteLine($"        Команда: create-user <логин> <пароль> <роль>");

        Console.WriteLine($"\n2. Создать новую задачу");
        Console.WriteLine($"\n3. Разлогиниться");
        Console.WriteLine($"        Команда: logout");

        Console.WriteLine($"\nВведите команду:");
    }

    private string RolesToString()
    {
        string roles = string.Empty;

        foreach (Role role in Enum.GetValues(typeof(Role)))
        {
            if (role == Role.Unathorized) continue;
            roles += role.ToString() + ", ";
        }

        roles = roles.Substring(0, roles.Length - 2);

        return roles;
    }
}
