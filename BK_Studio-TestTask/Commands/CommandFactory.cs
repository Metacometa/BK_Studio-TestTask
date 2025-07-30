public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly IParser parser;

    public CommandFactory(IAuthService authService, IParser parser)
    {
        this.authService = authService;
        this.parser = parser;
    }

    public ICommand TestCommand() => new TestCommand();
    public ICommand AuthCommand() => new AuthCommand(authService);
    public ICommand RegisterCommand() => new RegisterCommand(authService);
    public ICommand CreateUserCommand() => new CreateUserCommand(authService, parser);
}
