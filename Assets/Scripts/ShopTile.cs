using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ShopTile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rect;
    public IShopItem shopItem;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI buttonText;
    public Image shopItemIcon;

    public TextMeshProUGUI informationText;
    public string purchaseInfo;
    
    private void Awake()
    {
        buttonText.text = "M$ " + shopItem.GetCost();
    }

    public void OnBuyItemButtonPress()
    {
        shopItem.BuyItem();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if(informationText != null)
        {
            informationText.text = purchaseInfo;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if(informationText != null)
        {
            informationText.text = "";
        }
    }

    public void DisableButton()
    {
        button.interactable = false;
    }
}
