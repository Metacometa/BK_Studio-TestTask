using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    private Camera cam;
    private IEventBus eventBus;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private LayerMask focusMask;

    [SerializeField] private float focusOffset;

    public Vector3 target;

    public void Init(IEventBus eventBus)
    {
        cam = Camera.main;
        target = cam.transform.position;

        eventBus.OnZoomedCamera += ZoomCamera;
        eventBus.OnMovedCameraHorizontally += MoveCameraVertically;

        eventBus.OnDoubleClicked += FocusCamera;
        eventBus.OnSelectedInUI += FocusCamera;

        eventBus.OnRightClicked += RotateAroundTarget;

        eventBus.OnDeselectedAll += ResetTarget; 
        eventBus.OnDeselected += ResetTarget;
    }

    private void ZoomCamera(Vector3 zoom)
    {
        cam.transform.Translate(zoom.y * zoomSpeed * Vector3.forward * Time.deltaTime);
    }

    private void MoveCameraVertically(float value)
    {
        cam.transform.Translate(value * moveSpeed * Vector3.down * Time.deltaTime);
    }

    private void FocusCamera(Vector3 mousePosition)
    {
        Ray ray = cam.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, focusMask))
        {
            FocusCameraLogic(hit.transform.position);
        }
    }

    private void FocusCamera(ISelectable selectable)
    {
        if (selectable is MonoBehaviour sceneObj)
        {
            FocusCameraLogic(sceneObj.transform.position);
        }
    }

    private void RotateAroundTarget(float axis)
    {
        cam.transform.RotateAround(target, Vector3.up, axis * rotationSpeed * Time.deltaTime);
    }

    private void ResetTarget(ISelectable selectable)
    {
        if (selectable is MonoBehaviour sceneObj)
        {
            if (sceneObj.transform.position == target)
            {
                target = cam.transform.position;
            }
        }
    }

    private void ResetTarget()
    {
        target = cam.transform.position;
    }

    private void FocusCameraLogic(Vector3 position)
    {
        Vector3 offsetDir = (cam.transform.position - position).normalized;

        cam.transform.position = position - cam.transform.forward * focusOffset;

        target = position;
    }
}
