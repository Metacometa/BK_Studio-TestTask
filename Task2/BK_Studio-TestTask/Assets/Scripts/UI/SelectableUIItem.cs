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

        eventBus.OnMouseSelected += MouseSelectionHandler;
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

    private void MouseSelectionHandler(ISelectable obj)
    {
        if (obj == null)
        {
            selectionToggle.isOn = false;
        }
        else if (obj == target)
        {
            selectionToggle.isOn = true;
        }
    }

}
