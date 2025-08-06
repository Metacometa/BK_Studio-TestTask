using System;
using UnityEngine;

public interface IEventBus
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

    public void ZoomCamera(Vector3 zoom);
    public void MoveCameraHorizontally(float value);
    public void DoubleClick(Vector3 mousePos);
    public void RightClick(float value);


    public void SetActive(bool value);

    public void Select(ISelectable obj);
    public void Deselect(ISelectable obj);
    public void SelectAll();
    public void DeselectAll();

    public void LeftClick(Vector3 mousePos);
    public void ChangeColor(Color color);
}
