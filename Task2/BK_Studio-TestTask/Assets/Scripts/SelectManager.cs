using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour, ISeleсtManager
{
    private HashSet<ISelectable> selected;
    public void Init()
    {
        selected = new HashSet<ISelectable>();
    }
    public List<ISelectable> GetSelectedObjects => new List<ISelectable>(selected);

    public void Add(ISelectable obj)
    {
        obj.Select();
        selected.Add(obj);
    }

    public void Remove(ISelectable obj)
    {
        if (selected.Contains(obj))
        {
            obj.Deselect();
            selected.Remove(obj);
        }
    }
}
