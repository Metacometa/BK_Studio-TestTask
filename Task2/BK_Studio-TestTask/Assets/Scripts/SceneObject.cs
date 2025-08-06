using UnityEngine;

public class SceneObject : MonoBehaviour, ISceneObject
{
    public string Name => gameObject.name;

    private OutlineEffect outlineEffect;
    private RendererController rendererController;

    void Awake()
    {
        outlineEffect = GetComponent<OutlineEffect>();
        rendererController = GetComponent<RendererController>();
    }

    public void Select()
    {
        outlineEffect?.EnableOutline();
    }

    public void Deselect()
    {
        outlineEffect?.DisableOutline();
    }

    public void ModifyColor(Color color)
    {
        rendererController.SetColor(color);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
