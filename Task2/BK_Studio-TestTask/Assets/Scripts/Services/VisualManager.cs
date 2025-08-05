using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour, IVisualManager
{
    private ISeleсtManager seleсtManager;
    private IEventBus eventBus;

    public void Init(ISeleсtManager seleсtManager, IEventBus eventBus)
    {
        this.seleсtManager = seleсtManager;
        this.eventBus = eventBus;

        eventBus.OnColorChanged += SetColor;
    }

    private void SetColor(Color color)
    {
        List<ISelectable> selected = seleсtManager.GetSelectedObjects;

        foreach (ISelectable obj in selected)
        {
            if (obj is IModifiable modifiable)
            {
                modifiable.ModifyColor(color);
            }
        }
    }
}
