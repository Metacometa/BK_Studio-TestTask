using System.Text.RegularExpressions;

public class CommandParser : IParser
{
    public (string command, string[] args) ParseCommand(string input)
    {
        string[] splittedInput = input.Split(' ');
        string command = splittedInput[0];

        Regex regex = new Regex("\".*\"");

        string[] args = MatchRegexToStringArray(regex, input);

        return (command, args);
        //throw new NotImplementedException();
    }

    private string[] MatchRegexToStringArray(Regex regex, string input)
    {
        MatchCollection matches = regex.Matches(input);

        string[] args = new string[matches.Count];

        for (int i = 0; i < matches.Count; ++i)
        {
            args[0] = matches[i].Value;
        }

        return args;
    }
}