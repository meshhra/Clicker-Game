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

    public override void IncreaseEffectAmount()
    {
        int value = (int) (_boughtCounter * 0.23f);
        value = (value < 1)? 0 : value;
        _effectAmmount += value;
    }

    public override void IncreaseCost()
    {
        _cost += (int)(_boughtCounter * 13.45f * _cost);
    }
}
