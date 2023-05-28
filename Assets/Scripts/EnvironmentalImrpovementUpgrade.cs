using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalImrpovementUpgrade : IShopItem
{
    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= costs[currentTier] && currentTier < costs.Length)
        {
            GameStats.Instance.Currency -= costs[currentTier];
            GameStats.Instance.CombineEnvironmentalMultiplier(upgradeTiers[currentTier]);

            currentTier++;
            if(currentTier == costs.Length) shop.shopTiles.Remove(shopTile);
            shop.DisplayShop();
        }
    }
}
