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
        var parser = new TestParser();

        var commandFactory = new CommandFactory();
        var authCommandRegistry = new AuthCommandRegistry(commandFactory);

        var startScreen = new AuthScreen(authCommandRegistry, parser);

        return new Application(startScreen);
    }
}