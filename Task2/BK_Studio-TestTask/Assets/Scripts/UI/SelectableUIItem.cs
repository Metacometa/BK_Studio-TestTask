using UnityEngine;
using UnityEngine.UI;

public class SelectableUIItem : MonoBehaviour
{
    private ISele�tManager sele�tManager;
    private ISelectable target;

    private IEventBus eventBus;

    [SerializeField] private Toggle selectionToggle;
    [SerializeField] private Toggle viewToggle;

    [SerializeField] private Text label;

    public void Init(ISelectable target, string name, 
        ISele�tManager sele�tManager, IEventBus eventBus)
    {
        this.sele�tManager = sele�tManager;
        this.target = target;
        this.eventBus = eventBus;

        label.text = name;

        selectionToggle.onValueChanged.AddListener(OnSelectionToggled);

        eventBus.OnSelected += ToggleOn;
        eventBus.OnDeselected += ToggleOff;

        eventBus.OnSelectedAll += ToggleOn;
        eventBus.OnDeselectedAll += ToggleOff;
    }

    private void OnSelectionToggled(bool selected)
    {
        if (selected)
        {
            sele�tManager.Add(target);
        }
        else
        {
            sele�tManager.Remove(target);
        }
    }

    private void ToggleOn(ISelectable obj)
    {
        if (obj == target)
        {
            selectionToggle.isOn = true;
        }
    }

    private void ToggleOn() => selectionToggle.isOn = true;
    private void ToggleOff() => selectionToggle.isOn = false;

    private void ToggleOff(ISelectable obj)
    {
        if (obj == target)
        {
            selectionToggle.isOn = false;
        }
    }

}
