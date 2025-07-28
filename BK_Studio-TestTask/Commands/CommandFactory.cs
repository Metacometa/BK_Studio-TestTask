public class CommandFactory
{
    private readonly IAuthService authService;

    public CommandFactory(IAuthService authService)
    {
        this.authService = authService;
    }   

    public ICommand CreateTestCommand() => new TestCommand();
    public ICommand CreateAuthCommand() => new AuthCommand(authService);
}
