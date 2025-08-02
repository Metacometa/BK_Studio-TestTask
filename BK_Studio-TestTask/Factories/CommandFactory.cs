public class CommandFactory
{
    private readonly IAuthService authService;
    private readonly ITaskService taskService;

    private readonly IUserContextManager contextManager;
    private readonly IUserContext userContext;

    private readonly IParser parser;
    private readonly IConsoleRenderer renderer;

    public CommandFactory(IAuthService authService,
        ITaskService taskService,
        IUserContextManager contextManager, 
        IUserContext userContext,
        IParser parser, IConsoleRenderer renderer)
    {
        this.authService = authService;
        this.taskService = taskService;

        this.contextManager = contextManager;
        this.userContext = userContext;

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

    public ICommand CreateTaskCommand() => new CreateTaskCommand(taskService, parser,
        new BasePrinter("Создать новую задачу", 
            "create-task <название> <id_проекта> <описание>", renderer));

    public ICommand AddExecutorCommand() => new AddExecutorCommand(taskService, parser,
    new BasePrinter("Назначить работника на задачу",
        "add-executor <название_задачи> <имя_работника>", renderer));

    public ICommand ListTasksCommand() => new ListTasksCommand(contextManager,
        new BasePrinter("Просмотреть список всех задач",
            "list-tasks", renderer));

    public ICommand ListMyTasksCommand() => new ListMyTasksCommand(contextManager, userContext,
        new BasePrinter("Просмотреть список ваших задач",
            "my-tasks", renderer));

    //public ICommand ChangeStatusCommand() => new ChangeStatusCommand(authService, parser,
    //    new BasePrinter("", "", renderer));

    public ICommand ListStaffCommand() => new ListStaffCommand(contextManager,
        new BasePrinter("Получить список пользователей", 
            "list-staff", renderer));
}
