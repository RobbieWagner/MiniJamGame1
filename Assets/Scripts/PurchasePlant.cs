using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasePlant : IShopItem
{
    [SerializeField] GameObject plantGO;
    GameObject canvasGO;

    protected override void Start()
    {
        base.Start();
    }

    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= costs[currentTier] && currentTier < costs.Length)
        {
            GameStats.Instance.Currency -= costs[currentTier];
            PowerPlantScreenSingleton.Instance.AddPlant(plantGO);

            currentTier++;
            if(currentTier == costs.Length) shop.shopTiles.Remove(shopTile);
        }
    }
}