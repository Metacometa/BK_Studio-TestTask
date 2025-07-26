public interface IParser
{
    public abstract (string command, string[] args) ParseCommand(string input);
}
