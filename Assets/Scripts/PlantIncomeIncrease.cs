using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantIncomeIncrease : IShopItem
{
    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= costs[currentTier] && currentTier < costs.Length)
        {
            GameStats.Instance.Currency -= costs[currentTier];
            plant.ChangeIncomeAmount((int)upgradeTiers[currentTier]);

            currentTier++;
            if(currentTier == costs.Length) shop.shopTiles.Remove(shopTile);
            shop.DisplayShop();
        }
    }
}
