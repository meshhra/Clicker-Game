using UnityEngine;

[CreateAssetMenu()]
public class IncreaseClickPowerSO : ShopItemSO
{
    public override string Name()
    {
        return $"+${_effectAmmount} per Click";
    }

    public override void ApplyEffect()
    {
        GameManager.Instance.IncreaseClickPower(_effectAmmount);
    }
}
