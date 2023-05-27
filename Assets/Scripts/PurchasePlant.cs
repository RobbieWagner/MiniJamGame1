using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePlant : IShopItem
{
    [SerializeField] GameObject plantGO;
    GameObject canvasGO;

    List<UnlockByPurchase> purchaseUnlocks;

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
            if(currentTier == costs.Length) shop.shopTiles.Remove(shopTile);
            if(newCurrencyMaker != null) OnItemPurhcase(newCurrencyMaker);
        }
    }

    public delegate void OnItemPurchaseDelegate(CurrencyMaker currencyMaker);
    public event OnItemPurchaseDelegate OnItemPurhcase;
}
