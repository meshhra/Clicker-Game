using UnityEngine;

[CreateAssetMenu()]
public class IncreaseVelocitySO : ShopItemSO
{
    public override string Name()
    {
        return $"+${_effectAmmount} per Second";
    }

    public override void ApplyEffect()
    {
        GameManager.Instance.IncreaseIdelSpeedBy(_effectAmmount);
    }
    
    public override void IncreaseEffectAmount()
    {
        int value = (int) (_effectAmmount * ((_effectAmmount <= 1 )? 1.34f: 0.65f));
        value = (value < 1)? 0 : value;
        _effectAmmount += value;
    }

    public override void IncreaseCost()
    {
        _cost += (int)(_boughtCounter * 13.45f + _effectAmmount * 2.223f * 5);
    }
}
