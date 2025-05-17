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
        int value = (int) (_boughtCounter * 0.23f);
        value = (value < 1)? 1 : value;
        _effectAmmount += value;
    }

    public virtual void IncreaseCost()
    {
        _cost += (int)(baseCost + (_boughtCounter * 75) + _effectAmmount);
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
