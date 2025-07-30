public interface IScreenFactory
{
    public IScreen Create(ScreenType key);
    public IScreen CreateForRole(Role role);
    public void Register(ScreenType key, IScreen screen);
}
