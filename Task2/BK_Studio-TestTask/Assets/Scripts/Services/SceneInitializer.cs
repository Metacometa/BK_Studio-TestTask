using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private SelectManager selectManager;

    [SerializeField] private UserController userController;
    [SerializeField] private UIController uIContoller;

    public void Awake()
    {
        //SelectManager selectManager = new SelectManager();

        EventBus eventBus = new EventBus();

        objectManager?.Init();
        selectManager?.Init();
        inputManager?.Init(eventBus);

        userController.Init(eventBus, selectManager);


        List<SceneObject> sceneObjects = objectManager?.GetSceneObjects();

        uIContoller?.Init(sceneObjects, selectManager, eventBus); 
    }
}
