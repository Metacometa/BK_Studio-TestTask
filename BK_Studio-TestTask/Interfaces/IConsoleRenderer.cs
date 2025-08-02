public interface IConsoleRenderer
{
    public void PrintHeader();
    public void PrintEndLine();
    public void PrintSeparator();
    public void PrintInstruction(string input);
    public void PrintNotification(Notification notification);
    public void PrintColorized(string input, ConsoleColor color);
    public void PrintUserList(List<User> users, string currentLogin = "");
    public void PrintRoles();
}
