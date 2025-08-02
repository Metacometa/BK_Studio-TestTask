public enum ScreenType
{
    Auth, FirstRegister, Menu
}

public interface IScreen
{
    public void SendStartMessage();
    public void Show();
    public void HandleInput();
}
