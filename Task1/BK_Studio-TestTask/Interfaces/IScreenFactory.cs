public interface IScreenFactory
{
    public IScreen Create(ScreenType key);
    public void Register(ScreenType key, IScreen screen);
}
