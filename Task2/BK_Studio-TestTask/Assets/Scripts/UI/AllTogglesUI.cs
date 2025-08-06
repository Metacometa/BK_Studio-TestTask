using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllTogglesUI : MonoBehaviour
{
    private IEventBus eventBus;

    private ISeleñtManager seleñtManager;
    private ISceneObjectProvider objectProvider;

    [SerializeField] private Toggle viewToggle;
    [SerializeField] private Toggle selectionToggle;

    public void Init(IEventBus eventBus, 
        ISeleñtManager seleñtManager, ISceneObjectProvider objectProvider)
    {
        this.eventBus = eventBus;

        this.seleñtManager = seleñtManager;
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
                seleñtManager.Add(sceneObject);
            }
        }
        else
        {
            seleñtManager.RemoveAll();
        }
    }
}
