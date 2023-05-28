using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePlant : IShopItem
{
    [SerializeField] GameObject plantGO;
    GameObject canvasGO;

    List<UnlockByPurchase> purchaseUnlocks;

    [SerializeField] float environmentDeteriorationMultiplier;
    [SerializeField] float maintenanceMultiplier = 1f;

    protected override void Start()
    {
        base.Start();
    }

    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= costs[currentTier] && currentTier < costs.Length)
        {
            GameStats.Instance.Currency -= costs[currentTier];
            CurrencyMaker newCurrencyMaker = PowerPlantScreenSingleton.Instance.AddPlant(plantGO);

            currentTier++;
            if(currentTier == costs.Length) 
            {
                shop.RemoveItem(shopTile);
            }
            if(newCurrencyMaker != null) OnItemPurhcase(newCurrencyMaker);
            shop.DisplayShop();

            GameStats.Instance.CombineEnvironmentalMultiplier(environmentDeteriorationMultiplier);
            GameStats.Instance.CombineMaintenanceMultiplier(maintenanceMultiplier);
        }
    }

    public delegate void OnItemPurchaseDelegate(CurrencyMaker currencyMaker);
    public event OnItemPurchaseDelegate OnItemPurhcase;
}
