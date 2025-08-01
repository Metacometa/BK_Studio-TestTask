public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly IParser parser;
    private readonly IConsoleRenderer renderer;

    public CommandFactory(IAuthService authService, IParser parser, IConsoleRenderer renderer)
    {
        this.authService = authService;
        this.parser = parser;
        this.renderer = renderer;
    }

    public ICommand LogoutCommand() => new LogoutCommand(authService, 
        new BasePrinter("Разлогиниться", "logout", renderer));

    public ICommand AuthCommand() => new AuthCommand(authService, 
        new BasePrinter("Войти в систему", "auth <логин> <пароль>", renderer));

    public ICommand RegisterCommand() => new RegisterCommand(authService, 
        new BasePrinter("Войти в систему", "register <логин> <пароль>", renderer));

    public ICommand CreateUserCommand() => new CreateUserCommand(authService, parser,
        new CreateUserPrinter("Зарегистрировать нового пользователя",
            "create-user <логин> <пароль> <роль>", renderer));

    public ICommand ChangeStatusCommand() => new ChangeStatusCommand(authService, parser, 
        new BasePrinter("", "", renderer));
}
