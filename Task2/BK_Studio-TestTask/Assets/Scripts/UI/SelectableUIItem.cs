using UnityEngine;
using UnityEngine.UI;

public class SelectableUIItem : MonoBehaviour
{
    private ISeleñtManager seleñtManager;
    private ISelectable target;

    private IEventBus eventBus;

    [SerializeField] private Toggle selectionToggle;
    [SerializeField] private Toggle viewToggle;

    [SerializeField] private Text label;

    public void Init(ISelectable target, string name, 
        ISeleñtManager seleñtManager, IEventBus eventBus)
    {
        this.seleñtManager = seleñtManager;
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
            seleñtManager.Add(target);
        }
        else
        {
            seleñtManager.Remove(target);
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
