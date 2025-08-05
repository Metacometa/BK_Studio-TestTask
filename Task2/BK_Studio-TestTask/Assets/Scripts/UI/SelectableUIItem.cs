using UnityEngine;
using UnityEngine.UI;

public class SelectableUIItem : MonoBehaviour
{
    private ISele�tManager sele�tManager;
    private ISelectable target;

    [SerializeField] private Toggle SelectionToggle;
    [SerializeField] private Toggle ViewToggle;

    [SerializeField] private Text label;

    public void Init(ISelectable target, string name, ISele�tManager sele�tManager)
    {
        this.sele�tManager = sele�tManager;
        this.target = target;

        label.text = name;

        SelectionToggle.onValueChanged.AddListener(OnSelectionChanged);
    }

    private void OnSelectionChanged(bool selected)
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
}
