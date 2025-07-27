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
        var commands = CreateCommands();

        var commandHandler = new CommandHandler(parser, commands);
        var startScreen = new BaseScreen(new AuthorizationCommandFactory());

        return new Application(commandHandler, startScreen);
    }

    private static Dictionary<string, ICommand> CreateCommands()
    {
        var commands = new Dictionary<string, ICommand>
        {
            ["test"] = new TestCommand()
        };

        return commands;
    }
}