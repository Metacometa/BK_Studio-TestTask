using UnityEngine;

public class RendererController : MonoBehaviour, IRendererController
{
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        rend.material.color = color;
    }
}
