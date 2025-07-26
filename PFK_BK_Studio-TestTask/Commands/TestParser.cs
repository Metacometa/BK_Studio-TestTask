public class TestParser : IParser
{
    public (string command, string[] args) ParseCommand(string input)
    {
        string[] args = { "kek", "lol" };
        return ("testCommand", args);
        //throw new NotImplementedException();
    }
}