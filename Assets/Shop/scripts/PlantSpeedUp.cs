using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpeedUp : IShopItem
{

    //plant is the currency maker the shop item effects
    //cost is the cost of the item
    //unlock requirement is an event that will unlock the item
    //shopTile is the physical tile that will be placed in the scene.

    [SerializeField] private CurrencyMaker plant;

    [SerializeField] private int cost;
    [SerializeField] private UnlockRequirement unlockRequirement;
    bool unlocked;
    [SerializeField] GameObject shopTile;
    [SerializeField] Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
        unlockRequirement.OnUnlock += UnlockItem;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UnlockItem()
    {
        unlocked = true;
        shop.shopTiles.Add(shopTile);
        
        ShopTile addedShopTile = shop.shopTiles[shop.shopTiles.Count-1].GetComponent<ShopTile>();
        if(addedShopTile != null)
        {
            addedShopTile.shopItem = this;
        }
    }

    public override void BuyItem()
    {
        if(GameStats.Instance.Currency >= cost)
        {
            GameStats.Instance.Currency -= cost;
            shop.shopTiles.Remove(shopTile);
        }
    }
}
