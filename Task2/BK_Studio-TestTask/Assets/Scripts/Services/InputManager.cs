using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private IEventBus eventBus;

    private float lastClickTime = 0;
    [SerializeField] float doubleClickThreshold = 0.3f;


    public void Init(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            //Если клип был по UI, то ничего не делать
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            eventBus.LeftClick(mousePos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Если клип был по UI, то ничего не делать
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            DoubleClickLogic(mousePos);
        }

        if (Input.GetMouseButton(1))
        {
            float mouseAxis = Input.GetAxis("Mouse X");
            eventBus.RightClick(mouseAxis);
        }


        if (Input.GetMouseButton(2))
        {
            float mouseAxis = Input.GetAxis("Mouse Y");
            eventBus.MoveCameraHorizontally(mouseAxis);
        }

        eventBus.ZoomCamera(Input.mouseScrollDelta);
    }

    private void DoubleClickLogic(Vector3 mousePos)
    {
        if (Time.time - lastClickTime < doubleClickThreshold)
        {
            eventBus.DoubleClick(mousePos);
            lastClickTime = -1;
        }
        else
        {
            lastClickTime = Time.time;
        }
    }
}
