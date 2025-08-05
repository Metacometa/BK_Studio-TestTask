using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform scrollViewContent;
    [SerializeField] private GameObject selectableUIItem;

    [SerializeField] private ColorChangerUI colorChangerUI;

    public void Init(List<SceneObject> sceneObjects, ISele�tManager sele�tManager, IEventBus eventBus)
    {
        foreach (SceneObject sceneObject in sceneObjects)
        {
            var uiItem = Instantiate(selectableUIItem, scrollViewContent);

            if (uiItem.TryGetComponent(out SelectableUIItem selectableItem))
            {
                selectableItem.Init(sceneObject, sceneObject.Name, sele�tManager, eventBus);
            }
        }

        colorChangerUI.Init(eventBus);
    }
}
