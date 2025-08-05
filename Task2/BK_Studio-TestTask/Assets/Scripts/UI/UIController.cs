using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject selectableUIItem;

    public void Init(List<SceneObject> sceneObjects, ISeleñtManager seleñtManager)
    {
        foreach (SceneObject sceneObject in sceneObjects)
        {
            var uiItem = Instantiate(selectableUIItem, content);

            if (uiItem.TryGetComponent(out SelectableUIItem selectableItem))
            {
                selectableItem.Init(sceneObject, sceneObject.Name, seleñtManager);
            }
        }
    }
}
