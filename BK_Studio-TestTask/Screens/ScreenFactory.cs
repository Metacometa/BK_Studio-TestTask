public class ScreenFactory : IScreenFactory
{
    private readonly UserContext userContext;
    private readonly IParser parser;

    private readonly CommandFactory commandFactory;

    private readonly Dictionary<Role, IScreen> menuScreens;
    private readonly Dictionary<string, IScreen> screens;

    public ScreenFactory(UserContext userContext, 
        IParser parser, 
        CommandFactory commandFactory)
    {
        menuScreens = new Dictionary<Role, IScreen>();
        screens = new Dictionary<string, IScreen>();

        this.userContext = userContext;
        this.parser = parser;

        this.commandFactory = commandFactory;

        menuScreens = new Dictionary<Role, IScreen>()
        {
            [Role.Manager] = new ManagerScreen(userContext,
                new ManagerCommandRegistry(commandFactory),
                parser)
        };
    }

    public IScreen Create(string key)
    {
        if (screens.TryGetValue(key, out IScreen result))
        {
            result.Init();
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"Ошибка программы: невозможно создать экран с ключом {key}");
        }
    }

    public void Register(string name, IScreen screen)
    {
        screens[name] = screen;
    }

/*    public IScreen CreateAuthScreen()
    {
        return new AuthScreen(userContext, 
            new AuthCommandRegistry(commandFactory), 
            parser);
    }

    public IScreen CreateFirstStartScreen()
    {
        return new FirstStartScreen(userContext,
            new FirstRegisterCommandRegistry(commandFactory),
            parser);
    }*/

    public IScreen CreateMenuScreen()
    {
        var role = userContext.User.Role;
        return menuScreens[role];
    }

}
