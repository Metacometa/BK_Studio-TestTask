public class AuthCommand : ICommand
{
    public void Execute(string[] args)
    {
        Console.WriteLine("=====");

        Console.WriteLine("Auth Command:");
       
        foreach (string arg in args)
        {
            Console.WriteLine("Arg: " + arg);
        }

        Console.WriteLine("=====");
    }
}
