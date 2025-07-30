using System.Text.RegularExpressions;

public class Parser : IParser
{
    public (string command, string[] args) ParseCommand(string input)
    {
        string[] splittedInput = input.Split(' ');

        if (splittedInput.Length == 0) return ("", []); 

        string command = splittedInput[0];
        string[] args = new string[splittedInput.Length - 1];

        for (int i = 1; i < splittedInput.Length; i++)
        {
            args[i - 1] = splittedInput[i];
        }

        return (command, args);
    }

    public bool TryParseRole(string input, out Role role)
    {
        switch (input)
        {
            case "Manager":
                role = Role.Manager;
                return true;
            case "Emloyee":
                role = Role.Employee;
                return true;
            default:
                role = Role.Unathorized;
                return false;
        }
    }

    [Obsolete("На данный момент метод неактуален")]
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