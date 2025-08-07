using UnityEngine;
using UnityEngine.UI;

public class InterfaceSwitcherUI : MonoBehaviour
{   
    [SerializeField] private Button hideButton;

    [SerializeField] private GameObject objectToHide;

    void Awake()
    {
        hideButton.onClick.AddListener(HideInterface);
    }

    void HideInterface()
    {
        bool isActive = objectToHide.activeInHierarchy;
        objectToHide.SetActive(!isActive);
    }
}
