public interface IConsoleRenderer
{
    public void PrintHeader();
    public void PrintSubheader(string input);
    public void PrintEndLine();
    public void PrintSeparator();
    public void PrintInstruction(string input);
    public void PrintNotification(Notification notification);
    public void PrintColorized(string input, ConsoleColor color);
    public void PrintUserList(List<User> users, string currentLogin = "");
    public void PrintTaskList(List<Task> users);
    public void PrintMyTaskList(List<Task> users);
    public void PrintCommands(List<ICommand> commands);
    public void PrintRoles();
}
