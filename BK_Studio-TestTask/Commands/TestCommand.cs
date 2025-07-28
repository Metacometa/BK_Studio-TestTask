public class TestCommand : ICommand
{
    public void Execute(string[] args)
    {
        Console.WriteLine("=====");

        Console.WriteLine("TestCommand:");
       
        foreach (string arg in args)
        {
            Console.WriteLine("Arg: " + arg);
        }

        Console.WriteLine("=====");
    }
}
