using UnityEngine;
using UnityEngine.UI;

public class ColorChangerUI : MonoBehaviour
{
    private IEventBus eventBus;

    [SerializeField] private Slider rSlider;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Slider bSlider;
    [SerializeField] private Slider aSlider;

    public void Init(IEventBus eventBus)
    {
        this.eventBus = eventBus;

        rSlider.onValueChanged.AddListener(OnSliderChanged);
        gSlider.onValueChanged.AddListener(OnSliderChanged);
        bSlider.onValueChanged.AddListener(OnSliderChanged);
        aSlider.onValueChanged.AddListener(OnSliderChanged);

        eventBus.OnSelected += SetColor;
    }

    private void SetColor(ISelectable _)
    {
        eventBus?.ChangeColor(GetColor());
    }

    private void OnSliderChanged(float val)
    {
        eventBus?.ChangeColor(GetColor());
    }

    private Color GetColor()
    {
        return new Color(rSlider.value, gSlider.value, bSlider.value, aSlider.value);
    }
}
