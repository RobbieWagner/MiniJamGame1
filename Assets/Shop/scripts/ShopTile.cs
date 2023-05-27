using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTile : MonoBehaviour
{
    public RectTransform rect;
    public IShopItem shopItem;
    [SerializeField] private Button button;
    

    public void OnBuyItemButtonPress()
    {
        shopItem.BuyItem();
        button.enabled = false;
    }
}
