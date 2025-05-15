using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class ShopItemSO : ScriptableObject
{
    public int id;
    public string itemName;
    public int cost;
    public Image icon;
}
