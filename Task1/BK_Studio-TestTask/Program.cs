using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var app = CreateApplication();
            app.StartWorking();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
            Environment.Exit(1);
        }
    }

    private static Application CreateApplication()
    {
        var consoleTheme = new ConsoleTheme();

        var rolePrinter = new RolePrinter(consoleTheme);
        var notificationPrinter = new NotificationPrinter(consoleTheme);
        var taskPrinter = new TaskPrinter(consoleTheme);
        
        var consoleRenderer = new ConsoleRenderer(consoleTheme, rolePrinter, 
            notificationPrinter, taskPrinter);

        var userContext = new UserContext();

        UserRepository userRepository = null;
        TaskRepository taskRepository = null;
        try
        {
            userRepository = new UserRepository();
        }
        catch (Exception ex)
        {
            consoleRenderer.PrintColorized("[ОШИБКА]: Некорректные данные в базе данных пользователей",
                consoleTheme.errorColor);
            Console.WriteLine($"\n\nИнформация об ошибке:\n{ex.Message}");

            Environment.Exit(1);
        }

        try
        {
            taskRepository = new TaskRepository();
        }
        catch (Exception ex)
        {
            consoleRenderer.PrintColorized("[ОШИБКА]: Некорректные данные в базе данных задач",
                consoleTheme.errorColor);
            Console.WriteLine($"\n\nИнформация об ошибке:\n{ex.Message}");

            Environment.Exit(1);
        }

        var authService = new AuthService(userContext, userRepository!);
        var taskService = new TaskService(userContext, taskRepository!, userRepository!);
        var contextManager = new UserContextManager(userContext, taskRepository, userRepository!);

        var parser = new Parser();

        var commandFactory = new CommandFactory(authService, taskService, 
            contextManager, 
            userContext,
            parser, consoleRenderer);
        var screenFactory = new ScreenFactory();

        var firstStartRegistry = new CommandRegistry();
        var authRegistry = new CommandRegistry();
        var menuRegistry = new CommandRegistry();

        //Register first start commands
        firstStartRegistry.Register("register",
            [Role.Unathorized],
            commandFactory.RegisterCommand());

        //Register auth commands
        authRegistry.Register("auth",
            [Role.Unathorized],
            commandFactory.AuthCommand());

        //Register Manager commands in menu
        menuRegistry.Register("create-user",
            [Role.Manager],
            commandFactory.CreateUserCommand());

        menuRegistry.Register("create-task",
            [Role.Manager],
            commandFactory.CreateTaskCommand());

        menuRegistry.Register("add-executor",
            [Role.Manager],
            commandFactory.AddExecutorCommand());

        menuRegistry.Register("list-tasks",
            [Role.Manager],
            commandFactory.ListTasksCommand());

        menuRegistry.Register("list-staff",
            [Role.Manager],
            commandFactory.ListStaffCommand());

        //Register Employee commands in menu
        menuRegistry.Register("my-tasks",
            [Role.Employee],
            commandFactory.ListMyTasksCommand());

        menuRegistry.Register("change-status",
            [Role.Employee],
            commandFactory.ChangeTaskStatusCommand());

        menuRegistry.Register("logout",
            [Role.Employee, Role.Manager],
            commandFactory.LogoutCommand());


        //Register screens
        screenFactory.Register(ScreenType.FirstRegister, 
            new FirstRegisterScreen(userContext, firstStartRegistry, parser, consoleRenderer));

        screenFactory.Register(ScreenType.Auth, 
            new AuthScreen(userContext, authRegistry, parser, consoleRenderer));

        screenFactory.Register(ScreenType.Menu, 
            new MenuScreen(userContext, menuRegistry, parser, consoleRenderer));


        return new Application(userContext, userRepository, screenFactory);
    }
}