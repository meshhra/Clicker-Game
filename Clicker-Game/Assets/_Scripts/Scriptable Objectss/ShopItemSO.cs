using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSO : ScriptableObject
{
    [SerializeField] protected int baseCost;
    [SerializeField] protected int baseEffectAmount;

    protected int _cost;
    protected int _effectAmmount;
    protected int _boughtCounter;

    public virtual string Name() => "ShopItemSO";
    public virtual int Cost() => _cost;
    public virtual int EffectAmount() => _effectAmmount;
    public int BoughtAmount() => _boughtCounter;

    public void ResetActiveValues()
    {
        _effectAmmount = baseEffectAmount;
        _cost = baseCost;
        _boughtCounter = 0;
    }

    public virtual void IncreaseEffectAmount()
    {
        _effectAmmount = (int)(_effectAmmount + (_effectAmmount / 2) + 1 * _boughtCounter);

    }

    public virtual void IncreaseCost()
    {
        _cost += (int)(baseCost + (_boughtCounter * 75));
    }

    public void IncrementBoughtCounter()
    {
        _boughtCounter++;
    }

    public virtual void ApplyEffect()
    {
        Debug.Log("Base ShopItemSO.ApplyEffect");
    }
}
