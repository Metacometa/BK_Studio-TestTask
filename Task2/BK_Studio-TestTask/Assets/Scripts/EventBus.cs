using System;
using UnityEngine;

public class EventBus : IEventBus
{
    public event Action<Vector3> OnLeftClick;
    public event Action<ISelectable> OnMouseSelected;

    public void LeftClick(Vector3 mousePos)
    {
        OnLeftClick?.Invoke(mousePos);
    }

    public void MouseSelect(ISelectable obj)
    {
        OnMouseSelected?.Invoke(obj);
    }
}
