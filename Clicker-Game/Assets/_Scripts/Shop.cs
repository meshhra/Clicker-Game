using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] private List<ShopItemSO> itemSOList;
    [SerializeField] private GameObject itemUITemplate;

    [SerializeField] private Transform itemParent;

    private void Start()
    {
        foreach (ShopItemSO itemSO in itemSOList) 
        {
            //generate the shop for all the items
            var t = Instantiate(itemUITemplate, itemParent);
            ShopItemUI shopItemUI = t.gameObject.GetComponent<ShopItemUI>();
            shopItemUI.Initialize(itemSO);

            shopItemUI.ItemBought += HandelitemBought;
        }
    }

    private void HandelitemBought(ShopItemSO itemSO)
    {
        Debug.Log(itemSO);
        itemSO.ApplyEffect();
    }
}
