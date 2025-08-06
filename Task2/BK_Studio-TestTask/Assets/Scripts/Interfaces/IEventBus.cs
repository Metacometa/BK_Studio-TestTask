using System;
using UnityEngine;

public interface IEventBus
{
    public event Action<Vector3> OnLeftClick;

    public event Action<ISelectable> OnSelected;
    public event Action<ISelectable> OnDeselected;
    public event Action OnSelectedAll;
    public event Action OnDeselectedAll;

    public event Action<Color> OnColorChanged;

    public void Select(ISelectable obj);
    public void Deselect(ISelectable obj);
    public void SelectAll();
    public void DeselectAll();

    public void LeftClick(Vector3 mousePos);
    public void ChangeColor(Color color);
}
