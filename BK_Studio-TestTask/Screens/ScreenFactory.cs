public class ScreenFactory
{
    private readonly UserContext userContext;
    private readonly IParser parser;

    private readonly CommandFactory commandFactory;

    private readonly Dictionary<Role, IScreen> menuScreens;

    public ScreenFactory(UserContext userContext, 
        IParser parser, 
        CommandFactory commandFactory)
    {
        this.userContext = userContext;
        this.parser = parser;

        this.commandFactory = commandFactory;

        menuScreens = new Dictionary<Role, IScreen>()
        {
            [Role.Manager] = new ManagerMenuScreen(userContext,
                new ManagerCommandRegistry(commandFactory),
                parser)
        };
    }

    public IScreen CreateAuthScreen()
    {
        return new AuthScreen(userContext, 
            new AuthCommandRegistry(commandFactory), 
            parser);
    }

    public IScreen CreateFirstStartScreen()
    {
        return new FirstStartScreen(userContext,
            new FirstStartCommandRegistry(commandFactory),
            parser);
    }

    public IScreen CreateMenuScreen()
    {
        var role = userContext.User.Role;
        return menuScreens[role];
    }

}
