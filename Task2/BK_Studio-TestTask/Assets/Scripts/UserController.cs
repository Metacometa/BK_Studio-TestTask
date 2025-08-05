using UnityEngine;

public class UserController : MonoBehaviour
{
    private MouseSelection mouseSelection;
    private IEventBus eventBus;

    public void Init(IEventBus eventBus, ISeleñtManager selectManager)
    {
        if (TryGetComponent(out MouseSelection mouseSelection))
        {
            this.mouseSelection = mouseSelection;
            mouseSelection.Init(eventBus, selectManager);
        }

        eventBus.OnLeftClick += mouseSelection.MouseSelect;
    }

    void Update()
    {
        
    }
}
