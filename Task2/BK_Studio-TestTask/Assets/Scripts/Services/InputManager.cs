using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private IEventBus eventBus;

    public void Init(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Если клип был по UI, то ничего не делать
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Vector3 mousePos = Input.mousePosition;
            eventBus.LeftClick(mousePos);
        }
    }
}
