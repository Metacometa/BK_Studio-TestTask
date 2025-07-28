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

        return new Application(screenFactory);
    }
}