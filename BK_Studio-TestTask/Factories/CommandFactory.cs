public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly IDataService dataService;

    private readonly IParser parser;
    private readonly IConsoleRenderer renderer;

    public CommandFactory(IAuthService authService, IDataService dataService, 
        IParser parser, IConsoleRenderer renderer)
    {
        this.authService = authService;
        this.dataService = dataService;

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

    //public ICommand ChangeStatusCommand() => new ChangeStatusCommand(authService, parser,
    //    new BasePrinter("", "", renderer));

    public ICommand ListStaffCommand() => new ListStaffCommand(dataService,
        new BasePrinter("Получить список пользователей", 
            "list-staff", renderer));
}
