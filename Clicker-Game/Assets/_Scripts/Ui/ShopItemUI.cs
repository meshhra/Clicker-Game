using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public event Action<ShopItemSO> ItemBought;
    private ShopItemSO _itemSo;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCost;

    public void Initialize(ShopItemSO itemSo)
    {
        this._itemSo = itemSo;

        itemName.text = $"{itemSo.Name()}";
        itemCost.text = $"${itemSo.Cost()}";

        _itemSo.ResetActiveValues();
    }

    private void Update()
    {
        if (!_itemSo) return;
        if (GameManager.Instance.Score < _itemSo.Cost())
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
        itemName.text = $"{_itemSo.Name()}";
        itemCost.text = $"${_itemSo.Cost()}";
    }

    public void OnClick()
    {
        Debug.Log($"Something Clicked {_itemSo} {_itemSo.Cost()} {GameManager.Instance.Score}");
        if (_itemSo.Cost() < GameManager.Instance.Score)
        {
            ItemBought?.Invoke(_itemSo);
            GameManager.Instance.DecreaseScoreBy(_itemSo.Cost());
            _itemSo.IncrementBoughtCounter();

            //update the ui
            itemName.text = $"{_itemSo.Name()}";
            itemCost.text = $"${_itemSo.Cost()}";

            _itemSo.IncreaseCost();
            _itemSo.IncreaseEffectAmount();
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
}
