public class Application
{
    private readonly ICommandHandler handler;
    private IScreen screen;

    public Application(ICommandHandler handler, IScreen screen)
    {
        this.handler = handler ?? throw new ArgumentNullException(nameof(handler));
        this.screen = screen ?? throw new ArgumentNullException(nameof(screen));
    }

    public void StartWorking()
    {
        while (true)
        {
            screen.Show();
            //Console.WriteLine("Getting input");

            string input = Console.ReadLine();
        }
    }
}