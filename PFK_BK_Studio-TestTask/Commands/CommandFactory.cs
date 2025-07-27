public class CommandFactory
{
    public CommandFactory()
    {

    }

    public ICommand CreateTestCommand() => new TestCommand();
}
