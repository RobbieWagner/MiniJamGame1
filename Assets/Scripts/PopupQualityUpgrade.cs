using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupQualityUpgrade : IShopItem
{

    [SerializeField] private PopupDisplay popupDisplay;

    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= costs[currentTier] && currentTier < costs.Length)
        {
            GameStats.Instance.Currency -= costs[currentTier];
            popupDisplay.ReduceNegativePopupChance(upgradeTiers[currentTier]);

            currentTier++;
            if(currentTier == costs.Length) shop.shopTiles.Remove(shopTile);
            shop.DisplayShop();
        }
    }
}
