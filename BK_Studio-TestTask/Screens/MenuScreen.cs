public class MenuScreen : BaseScreen
{
    public MenuScreen(IUserContext userContext, ICommandRegistry commandRegistry, 
        IParser parser, IConsoleRenderer renderer) 
            : base(userContext, commandRegistry, parser, renderer) 
    {
        
    }

    public override void SendStartMessage()
    {
        userContext.Notification = new Notification(NotificationType.Info,
            $"Здравствуйте, {userContext.User.Login}!" +
            $"\nВаша роль: {userContext.User.Role}");
    }

    public override void Show()
    {
        List<ICommand> commands = commandRegistry.GetCommandsByRole(userContext.User.Role);


        renderer.PrintHeader();
        renderer.PrintNotification(userContext.Notification);

        renderer.PrintUserList(userContext.UserList, userContext.User.Login);
        renderer.PrintTaskList(userContext.TaskList);
        renderer.PrintMyTaskList(userContext.MyTaskList);

        renderer.PrintCommands(commands);

        renderer.PrintEndLine();
        Console.Write($"> ");

        EventBus.Instance.TriggerScreenDisplayer();
    }
}
