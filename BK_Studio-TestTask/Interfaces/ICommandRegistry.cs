public interface ICommandRegistry
{
    public void Register(string name, Role[] roles, ICommand command);
    public ICommand GetCommand(string name, Role role);
}