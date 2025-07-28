public interface IScreenFactory
{
    public IScreen Create(string key);
    public void Register(string name, IScreen screen);
}
