public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly IParser parser;

    public CommandFactory(IAuthService authService, IParser parser)
    {
        this.authService = authService;
        this.parser = parser;
    }

    public ICommand LogoutCommand() => new LogoutCommand(authService);
    public ICommand AuthCommand() => new AuthCommand(authService);
    public ICommand RegisterCommand() => new RegisterCommand(authService);
    public ICommand CreateUserCommand() => new CreateUserCommand(authService, parser);
    public ICommand ChangeStatusCommand() => new ChangeStatusCommand(authService, parser);
}
