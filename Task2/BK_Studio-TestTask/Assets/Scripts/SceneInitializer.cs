using System.Collections.Generic;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private SelectManager selectManager;
    [SerializeField] private UIController uIContoller;

    public void Awake()
    {
        objectManager?.Init();
        selectManager?.Init();

        List<SceneObject> sceneObjects = objectManager?.GetSceneObjects();


        uIContoller?.Init(sceneObjects, selectManager); 
    }
}
