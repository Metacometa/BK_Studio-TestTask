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
        var consoleRenderer = new ConsoleRenderer(consoleTheme, rolePrinter, notificationPrinter);

        var userContext = new UserContext();

        UserRepository userRepository = null;
        UserRepository taskRepository = null;
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
            taskRepository = new UserRepository();
        }
        catch (Exception ex)
        {
            consoleRenderer.PrintColorized("[ОШИБКА]: Некорректные данные в базе данных задач",
                consoleTheme.errorColor);
            Console.WriteLine($"\n\nИнформация об ошибке:\n{ex.Message}");

            Environment.Exit(1);
        }

        var authService = new AuthService(userContext, userRepository!);
        var dataService = new DataService(userContext, userRepository!);

        var parser = new Parser();

        var commandFactory = new CommandFactory(authService, dataService, parser, consoleRenderer);
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

        //Register menu commands
        menuRegistry.Register("create-user",
            [Role.Manager],
            commandFactory.CreateUserCommand());

        menuRegistry.Register("list-staff",
            [Role.Manager],
            commandFactory.ListStaffCommand());

        /*        menuRegistry.Register("change-status",
                    [Role.Employee],
                    commandFactory.ChangeStatusCommand());*/

        menuRegistry.Register("logout",
            [Role.Employee, Role.Manager],
            commandFactory.LogoutCommand());


        //Register screens
        screenFactory.Register(ScreenType.FirstRegister, 
            new FirstRegisterScreen(userContext, firstStartRegistry, parser, consoleRenderer));

        screenFactory.Register(ScreenType.Auth, 
            new AuthScreen(userContext, authRegistry, parser, consoleRenderer));

        screenFactory.Register(ScreenType.ManagerMenu, 
            new ManagerScreen(userContext, menuRegistry, parser, consoleRenderer));



/*        screenFactory.Register("employee", new FirstRegisterScreen(userContext,
new FirstRegisterCommandRegistry(commandFactory),
parser));*/



        return new Application(userContext, userRepository, screenFactory);
    }
}