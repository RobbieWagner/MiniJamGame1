using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTile : MonoBehaviour
{
    public RectTransform rect;
    public IShopItem shopItem;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;
    public Image shopItemIcon;
    
    private void Awake()
    {
        buttonText.text = "M$ " + shopItem.GetCost();
    }

    public void OnBuyItemButtonPress()
    {
        shopItem.BuyItem();
    }

    public void DisableButton()
    {
        button.interactable = false;
    }
}
