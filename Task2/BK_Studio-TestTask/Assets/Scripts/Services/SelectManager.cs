using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour, ISeleсtManager
{
    private IEventBus eventBus;

    private HashSet<ISelectable> selected;
    public List<ISelectable> GetSelectedObjects => new List<ISelectable>(selected);

    public void Init(IEventBus eventBus)
    {
        this.eventBus = eventBus;

        selected = new HashSet<ISelectable>();
    }
    
    public void Add(ISelectable obj)
    {
        obj.Select();
        selected.Add(obj);

        eventBus.Select(obj);
    }

    public void Remove(ISelectable obj)
    {
        if (selected.Contains(obj))
        {
            obj.Deselect();
            selected.Remove(obj);

            eventBus.Deselect(obj);
        }
    }

    public void RemoveAll()
    {
        foreach (ISelectable obj in selected)
        {
            obj.Deselect();

        }
        eventBus.DeselectAll();

        selected.Clear();
    }

    public bool Contains(ISelectable obj)
    {
        return selected.Contains(obj);
    }
}
