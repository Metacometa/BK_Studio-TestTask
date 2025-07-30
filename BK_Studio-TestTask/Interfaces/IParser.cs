public interface IParser
{
    public abstract (string command, string[] args) ParseCommand(string input);
    public abstract bool TryParseRole(string input, out Role role);
    //public abstract (string command, string[] args) ParseCommand(string input);
}
