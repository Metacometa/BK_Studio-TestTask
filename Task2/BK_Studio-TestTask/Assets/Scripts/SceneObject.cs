using UnityEngine;

public class SceneObject : MonoBehaviour, ISceneObject
{
    public string Name => gameObject.name;

    private OutlineEffect outlineEffect;

    void Awake()
    {
        outlineEffect = GetComponent<OutlineEffect>();
    }

    public void Select()
    {
        outlineEffect?.EnableOutline();
    }

    public void Deselect()
    {
        outlineEffect?.DisableOutline();
    }
}
