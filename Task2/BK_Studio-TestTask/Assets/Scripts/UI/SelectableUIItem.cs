using UnityEngine;
using UnityEngine.UI;

public class SelectableUIItem : MonoBehaviour
{
    private ISeleñtManager seleñtManager;
    private ISelectable target;

    [SerializeField] private Toggle SelectionToggle;
    [SerializeField] private Toggle ViewToggle;

    [SerializeField] private Text label;

    public void Init(ISelectable target, string name, ISeleñtManager seleñtManager)
    {
        this.seleñtManager = seleñtManager;
        this.target = target;

        label.text = name;

        SelectionToggle.onValueChanged.AddListener(OnSelectionChanged);
    }

    private void OnSelectionChanged(bool selected)
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
}
