using UnityEngine;

public class OutlineEffect : MonoBehaviour, IOutlineEffect
{
    private Renderer rend;
    private MaterialPropertyBlock propertyBlock;

    [SerializeField] private string propertyName = "_OutlineEnabled";

    private void Awake()
    {
        rend = GetComponent<Renderer>();

        propertyBlock = new MaterialPropertyBlock();
    }

    public void EnableOutline()
    {
        SetProperty(true);
    }

    public void DisableOutline()
    {
        SetProperty(false);
        Debug.Log("DiasbleOutline");
    }

    private void SetProperty(bool enabled)
    {
        rend?.GetPropertyBlock(propertyBlock);

        propertyBlock.SetFloat(propertyName, enabled ? 1f : 0f);

/*        if (propertyBlock.HasProperty(propertyName))
        {
            Debug.Log("True");
            //propertyBlock.SetFloat(propertyName, enabled ? 1f : 0f);
        }
        else
        {
            Debug.Log("False");
        }*/

        rend?.SetPropertyBlock(propertyBlock);
    }

}
