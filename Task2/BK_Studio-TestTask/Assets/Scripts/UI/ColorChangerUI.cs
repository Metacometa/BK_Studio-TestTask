using UnityEngine;
using UnityEngine.UI;

public class ColorChangerUI : MonoBehaviour
{
    private IEventBus eventBus;

    [SerializeField] private Slider rSlider;
    [SerializeField] private Slider gSlider;
    [SerializeField] private Slider bSlider;

    public void Init(IEventBus eventBus)
    {
        this.eventBus = eventBus;

        rSlider.onValueChanged.AddListener(OnSliderChanged);
        gSlider.onValueChanged.AddListener(OnSliderChanged);
        rSlider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float val)
    {
        float r = rSlider.value;
        float g = gSlider.value;
        float b = bSlider.value;

        eventBus?.ChangeColor(new Color(r, g, b));
    }
}
