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
        var userContext = new UserContext();
        var userRepository = new UserRepository();

        var authService = new AuthService(userContext, userRepository);
        var parser = new Parser();

        var commandFactory = new CommandFactory(authService, parser);
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

        menuRegistry.Register("change-status",
            [Role.Employee],
            commandFactory.ChangeStatusCommand());

        menuRegistry.Register("logout",
            [Role.Employee, Role.Manager],
            commandFactory.LogoutCommand());


        //Register screens
        screenFactory.Register("registerScreen", new FirstRegisterScreen(userContext,
            firstStartRegistry,
            parser));

        screenFactory.Register("authScreen", new AuthScreen(userContext,
            authRegistry,
            parser));

        screenFactory.Register("managerScreen", new ManagerScreen(userContext,
            menuRegistry,
            parser));



/*        screenFactory.Register("employee", new FirstRegisterScreen(userContext,
new FirstRegisterCommandRegistry(commandFactory),
parser));*/



        return new Application(userContext, userRepository, screenFactory);
    }
}