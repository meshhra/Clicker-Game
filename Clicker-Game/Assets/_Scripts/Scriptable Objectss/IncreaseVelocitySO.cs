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
        GameManager.Instance.IncreaseIdelSppedBy(_effectAmmount);
    }

}
