using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeterUI : MonoBehaviour
{
    [SerializeField] private Image meterFillImage;
    [SerializeField] private TextMeshProUGUI meterText;

    private void Start()
    {
        meterText.gameObject.SetActive(false);
    }

    public void SetImageFill(float current, float max)
    {
        meterFillImage.fillAmount = current / max;
        if (GameManager.Instance.IsMultiplayerEnabled)
        {
            if(!meterText.gameObject.activeInHierarchy) meterText.gameObject.SetActive(true);
            meterText.text = (max).ToString() + "x";
        }
        else
        {
            meterText.gameObject.SetActive(false);
        }
    }
}
