public class Application
{
    private readonly ICommandHandler handler;

    public Application(ICommandHandler handler)
    {
        this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public void StartWorking()
    {
        while (true)
        {
            Console.WriteLine("Getting input");

            string input = Console.ReadLine();
        }
    }
}