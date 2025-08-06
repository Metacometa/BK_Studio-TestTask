using UnityEngine;

public class UserController : MonoBehaviour
{
    private IEventBus eventBus;

    public void Init(IEventBus eventBus, ISeleñtManager selectManager)
    {
        if (TryGetComponent(out MouseSelection mouseSelection))
        {
            mouseSelection.Init(eventBus, selectManager);
        }

        if (TryGetComponent(out CameraController cameraController))
        {
            cameraController.Init(eventBus);
        }

        eventBus.OnLeftClick += mouseSelection.MouseSelect;
    }
}
