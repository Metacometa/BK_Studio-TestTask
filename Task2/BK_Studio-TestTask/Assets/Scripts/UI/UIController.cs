using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject selectableUIItem;

    [SerializeField] private ColorChangerUI colorChangerUI;
    [SerializeField] private AllTogglesUI allToggllesUI;

    public void Init(List<ISceneObject> sceneObjects, ISeleñtManager seleñtManager,
        IEventBus eventBus, ISceneObjectProvider sceneObjectProvider)
    {
        foreach (SceneObject sceneObject in sceneObjects)
        {
            var uiItem = Instantiate(selectableUIItem, scrollViewContent);

            if (uiItem.TryGetComponent(out SelectableUIItem selectableItem))
            {
                selectableItem.Init(sceneObject, sceneObject.Name, seleñtManager, eventBus);
            }
        }

        colorChangerUI.Init(eventBus);
        allToggllesUI.Init(eventBus, seleñtManager, sceneObjectProvider);
    }
}
