using System.Collections.Generic;

public interface ISeleсtManager
{
    public List<ISelectable> GetSelectedObjects { get; }
    public void Add(ISelectable obj);
    public void Remove(ISelectable obj);
    public void RemoveAll();
    public bool Contains(ISelectable obj);
}