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

    private void HandelitemBought(int itemId)
    {
        Debug.Log(itemId);

        switch(itemId)
        {
            case 0:
                GameManager.Instance.IncreaseClickPower(10);
                break;
            case 1:
                GameManager.Instance.IncreaseidelSppedBy(50);
                break;
            default:
                Debug.Log("Nothing wroks bro");
                break;
        }
    }
}
