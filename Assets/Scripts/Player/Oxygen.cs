using UnityEngine;
using UnityEngine.UI;

public class Oxygen : MonoBehaviour
{
    [SerializeField]
    private Slider oxygenSlider;

    public void setMaxOxygen(int oxygen)
    {
        oxygenSlider.maxValue = oxygen;
        oxygenSlider.value = oxygen;
    }

    public void setOxygen(int oxygen)
    {
        oxygenSlider.value = oxygen;
    }
}
