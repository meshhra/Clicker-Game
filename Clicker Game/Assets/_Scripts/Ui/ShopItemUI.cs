using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public event Action<int> ItemBought;
    private ShopItemSO _itemSo;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;

    public void Initialize(ShopItemSO itemSo)
    {
        this._itemSo = itemSo;

        itemName.text = $"{itemSo.itemName}";
        itemCost.text = $"${itemSo.cost}";
    }

    private void Update()
    {
        if (!_itemSo) return;
        if (GameManager.Instance.Score < _itemSo.cost)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void OnClick()
    {
        Debug.Log("Something Clicked");
        if (_itemSo.cost < GameManager.Instance.Score)
        {
            ItemBought?.Invoke(_itemSo.id);
            GameManager.Instance.DecreaseScoreBy(_itemSo.cost);
        }
        //tComponent<Button>().

        EventSystem.current.SetSelectedGameObject(null);
    }
}
