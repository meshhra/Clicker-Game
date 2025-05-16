using UnityEngine;
using UnityEngine.UI;

public class MeterUI : MonoBehaviour
{
    [SerializeField] private Image meterFillImage;

    public void SetImageFill(float current, float max)
    {
        meterFillImage.fillAmount = current / max;
    }
}
