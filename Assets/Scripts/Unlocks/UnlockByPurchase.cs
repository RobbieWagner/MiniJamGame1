using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockByPurchase : MonoBehaviour
{
    [SerializeField] private UnlockRequirement unlockRequirement;
    [SerializeField] private IShopItem shopItem;
    [SerializeField] PurchasePlant purchasePlant;

    private void Awake() 
    {
        purchasePlant.OnItemPurhcase += FulfillUnlockRequirement;
    }

    private void FulfillUnlockRequirement(CurrencyMaker currencyMaker)
    {
        shopItem.SetPlant(currencyMaker);
        unlockRequirement.Unlocked = true;
    }
}
