using System;
using UnityEngine;

public class EventBus : IEventBus
{
    public event Action<Vector3> OnLeftClick;

    public event Action<ISelectable> OnSelected;
    public event Action<ISelectable> OnDeselected;
    public event Action OnSelectedAll;
    public event Action OnDeselectedAll;

    public event Action<Color> OnColorChanged;

    public void Select(ISelectable obj)
    {
        OnSelected?.Invoke(obj);
    }
    public void Deselect(ISelectable obj)
    {
        OnDeselected?.Invoke(obj);
    }
    public void SelectAll()
    {
        OnSelectedAll?.Invoke();
    }
    public void DeselectAll()
    {
        OnDeselectedAll?.Invoke();
    }


    public void LeftClick(Vector3 mousePos)
    {
        OnLeftClick?.Invoke(mousePos);
    }

    public void ChangeColor(Color color)
    {
        OnColorChanged?.Invoke(color);
    }
}
