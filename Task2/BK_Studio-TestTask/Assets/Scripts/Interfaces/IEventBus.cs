using System;
using UnityEngine;

public interface IEventBus
{
    public event Action<Vector3> OnLeftClick;
    public event Action<ISelectable> OnMouseSelected;

    public void LeftClick(Vector3 mousePos);
    public void MouseSelect(ISelectable obj);
}
