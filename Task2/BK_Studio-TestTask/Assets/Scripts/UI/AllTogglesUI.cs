using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTogglesUI : MonoBehaviour
{
    private IEventBus eventBus;

    private ISele�tManager sele�tManager;
    private ISceneObjectProvider objectProvider;

    [SerializeField] private Toggle viewToggle;
    [SerializeField] private Toggle selectionToggle;

    public void Init(IEventBus eventBus, 
        ISele�tManager sele�tManager, ISceneObjectProvider objectProvider)
    {
        this.eventBus = eventBus;

        this.sele�tManager = sele�tManager;
        this.objectProvider = objectProvider;

        selectionToggle.onValueChanged.AddListener(OnSelectionToggled);
    }

    private void OnSelectionToggled(bool selected)
    {
        if (selected)
        {
            List<ISceneObject> sceneObjects = objectProvider.GetSceneObjects();

            foreach (ISceneObject sceneObject in sceneObjects)
            {
                sele�tManager.Add(sceneObject);
            }
        }
        else
        {
            sele�tManager.RemoveAll();
        }
    }
}
