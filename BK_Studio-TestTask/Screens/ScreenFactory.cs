public class ScreenFactory : IScreenFactory
{
    private readonly Dictionary<ScreenType, IScreen> screens;

    public ScreenFactory()
    {
        screens = new Dictionary<ScreenType, IScreen>();
    }

    public IScreen Create(ScreenType key)
    {
        if (screens.TryGetValue(key, out IScreen result))
        {
            result.SendStartMessage();
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"[ОШИБКА]: Невозможно создать экран с ключом \"{key}\"");
        }
    }

    public IScreen CreateForRole(Role role)
    {
        switch (role)
        {
            case Role.Employee:
                return Create(ScreenType.EmployeeMenu);
            case Role.Manager:
                return Create(ScreenType.ManagerMenu);
            default:
                return null;
        }
    }

    public void Register(ScreenType key, IScreen screen)
    {
        if (screens.ContainsKey(key))
        {
            throw new InvalidOperationException($"[ОШИБКА]: Попытка переопределить экран \"{key}\"");
        }

        screens[key] = screen;
    }
}
