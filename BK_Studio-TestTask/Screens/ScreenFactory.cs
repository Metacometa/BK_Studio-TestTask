public class ScreenFactory
{
    private readonly IUserContext userContext;
    private readonly IParser parser;

    private readonly CommandFactory commandFactory;

    public ScreenFactory(IUserContext userContext, 
        IParser parser, 
        CommandFactory commandFactory)
    {
        this.userContext = userContext;
        this.parser = parser;

        this.commandFactory = commandFactory;
    }

    public IScreen CreateAuthScreen()
    {
        return new AuthScreen(userContext, 
            new AuthCommandRegistry(commandFactory), 
            parser);
    }

    public IScreen CreateManagerMenuScreen() => null;
}
