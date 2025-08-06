using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private SelectManager selectManager;
    [SerializeField] private VisualManager visualManager;

    [SerializeField] private UserController userController;
    [SerializeField] private UIController uIContoller;

    public void Awake()
    {
        //SelectManager selectManager = new SelectManager();

        EventBus eventBus = new EventBus();

        objectManager?.Init();
        selectManager?.Init(eventBus);

        visualManager?.Init(selectManager, eventBus);
        inputManager?.Init(eventBus);

        userController.Init(eventBus, selectManager);


        List<ISceneObject> sceneObjects = objectManager?.GetSceneObjects();

        uIContoller?.Init(sceneObjects, selectManager, eventBus, objectManager); 
    }
}
