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
        var screenFactory = new ScreenFactory(userContext, parser, commandFactory);

        try
        {
            screenFactory.Register("authScreen", new AuthScreen(userContext,
                new AuthCommandRegistry(commandFactory),
                parser));

            screenFactory.Register("registerScreen", new FirstRegisterScreen(userContext,
                new RegisterCommandRegistry(commandFactory),
                parser));

            screenFactory.Register("managerScreen", new ManagerScreen(userContext,
                new ManagerCommandRegistry(commandFactory),
                parser));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Внутренняя ошибка: {ex.Message}");

            Environment.Exit(1);
        }


/*        screenFactory.Register("employee", new FirstRegisterScreen(userContext,
new FirstRegisterCommandRegistry(commandFactory),
parser));*/



        return new Application(userContext, userRepository, screenFactory);
    }
}