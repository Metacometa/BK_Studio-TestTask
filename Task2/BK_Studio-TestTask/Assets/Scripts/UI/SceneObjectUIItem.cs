using UnityEngine;
using UnityEngine.UI;

public class SceneObjectUIItem : MonoBehaviour
{
    private ISeleñtManager seleñtManager;
    private ISceneObject target;

    private IEventBus eventBus;

    [SerializeField] private Toggle selectionToggle;
    [SerializeField] private Toggle viewToggle;

    [SerializeField] private Text label;

    public void Init(ISceneObject target, string name, 
        ISeleñtManager seleñtManager, IEventBus eventBus)
    {
        this.seleñtManager = seleñtManager;
        this.target = target;
        this.eventBus = eventBus;

        label.text = name;

        selectionToggle.onValueChanged.AddListener(OnSelectionToggled);
        viewToggle.onValueChanged.AddListener(OnViewToggled);

        eventBus.OnSelected += SelectionToggleOn;
        eventBus.OnDeselected += SelectionToggleOff;

        eventBus.OnSelectedAll += SelectionToggleOn;
        eventBus.OnDeselectedAll += SelectionToggleOff;


        eventBus.OnSetActive += ViewToggle;
    }

    private void OnSelectionToggled(bool selected)
    {
        if (selected)
        {
            seleñtManager.Add(target);
            eventBus.SelectInUI(target);
        }
        else
        {
            seleñtManager.Remove(target);
        }
    }

    private void OnViewToggled(bool value)
    {
        target.SetActive(value);
    }


    private void ViewToggle(bool value)
    {
        viewToggle.isOn = value;
    }


    private void SelectionToggleOn(ISelectable obj)
    {
        if (obj == target)
        {
            selectionToggle.isOn = true;
        }
    }

    private void SelectionToggleOff(ISelectable obj)
    {
        if (obj == target)
        {
            selectionToggle.isOn = false;
        }
    }

    private void SelectionToggleOn() => selectionToggle.isOn = true;
    private void SelectionToggleOff() => selectionToggle.isOn = false;
}
