using UnityEngine;

public class MouseSelection : MonoBehaviour, IMouseSelection
{
    private IEventBus eventBus;
    private ISeleсtManager selectManager;

    [SerializeField] private LayerMask selectionMask;

    public void Init(IEventBus eventBus, ISeleсtManager selectManager)
    {
        this.eventBus = eventBus;
        this.selectManager = selectManager;
    }

    public void MouseSelect(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, selectionMask))
        {
            if (hit.collider.TryGetComponent(out ISelectable obj))
            {
                selectManager.Add(obj);
            }
        }
        else
        {
            selectManager.RemoveAll();
        }
    }
}
