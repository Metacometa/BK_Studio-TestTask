public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly IParser parser;

    public CommandFactory(IAuthService authService, IParser parser)
    {
        this.authService = authService;
        this.parser = parser;
    }

    public ICommand LogoutCommand() => new LogoutCommand(authService, "Разлогиниться", "logout");
    public ICommand AuthCommand() => new AuthCommand(authService, "Войти в систему", "auth <логин> <пароль>");
    public ICommand RegisterCommand() => new RegisterCommand(authService, "Войти в систему", 
        "register <логин> <пароль>");

    public ICommand CreateUserCommand() => new CreateUserCommand(authService, parser, 
        "Зарегистрировать нового пользователя",
        "create-user <логин> <пароль> <роль>");

    public ICommand ChangeStatusCommand() => new ChangeStatusCommand(authService, parser, 
        "",
        "");
}
