public enum ScreenType
{
    Auth, FirstRegister, ManagerMenu, EmployeeMenu
}

public interface IScreen
{
    public void SendStartMessage();
    public void Show();
    public void HandleInput();
}
