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
            Console.WriteLine($"Ошибка: {ex.Message}");
            Environment.Exit(1);
        }
    }

    private static Application CreateApplication()
    {
        var userContext = new UserContext();
        var userRepository = new UserRepository();

        var authService = new AuthService(userContext, userRepository);
        var parser = new CommandParser();

        var commandFactory = new CommandFactory(authService);
        var screenFactory = new ScreenFactory(userContext, parser, commandFactory);

        //перенести регистрацию из комманд фактори и и скрин фактори сюда
        try
        {
            screenFactory.Register("auth", new AuthScreen(userContext,
                new AuthCommandRegistry(commandFactory),
                parser));

            screenFactory.Register("register", new FirstRegisterScreen(userContext,
                new FirstRegisterCommandRegistry(commandFactory),
                parser));

            screenFactory.Register("manager", new ManagerScreen(userContext,
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