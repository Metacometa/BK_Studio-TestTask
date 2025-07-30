public class ScreenFactory : IScreenFactory
{
    private readonly Dictionary<string, IScreen> screens;

    public ScreenFactory()
    {
        screens = new Dictionary<string, IScreen>();
    }

    public IScreen Create(string key)
    {
        if (screens.TryGetValue(key, out IScreen result))
        {
            result.SendStartMessage();
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"Ошибка программы: невозможно создать экран с ключом \"{key}\"");
        }
    }

    public void Register(string name, IScreen screen)
    {
        if (screens.ContainsKey(name))
        {
            throw new InvalidOperationException($"Внутренняя ошибка: попытка переопределить экран \"{name}\"");
        }

        screens[name] = screen;
    }
}
