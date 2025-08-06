using System;
using UnityEngine;

public class EventBus : IEventBus
{
    public event Action<Vector3> OnLeftClick;
    public event Action<Vector3> OnDoubleClicked;
    public event Action<float> OnRightClicked;

    public event Action<ISelectable> OnSelected;
    public event Action<ISelectable> OnDeselected;
    public event Action OnSelectedAll;
    public event Action OnDeselectedAll;

    public event Action<bool> OnSetActive;
    public event Action<Color> OnColorChanged;

    public event Action<Vector3> OnZoomedCamera;
    public event Action<float> OnMovedCameraHorizontally;

    public void RightClick(float value)
    {
        OnRightClicked?.Invoke(value);
    }

    public void ZoomCamera(Vector3 zoom)
    {
        OnZoomedCamera?.Invoke(zoom);
    }

    public void MoveCameraHorizontally(float value)
    {
        OnMovedCameraHorizontally?.Invoke(value);
    }

    public void DoubleClick(Vector3 mousePos)
    {
        OnDoubleClicked?.Invoke(mousePos);
    }


    public void SetActive(bool value)
    {
        OnSetActive?.Invoke(value);
    }


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
