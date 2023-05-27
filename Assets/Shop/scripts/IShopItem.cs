using UnityEngine;

public class IShopItem : MonoBehaviour
{ 

    [SerializeField] protected CurrencyMaker plant;

    [SerializeField] protected int cost;
    [SerializeField] protected UnlockRequirement unlockRequirement;
    protected bool unlocked;
    [SerializeField] protected GameObject shopTile;
    [SerializeField] protected Shop shop;
    [SerializeField] protected Sprite shopItemIcon;

    protected virtual void Start()
    {
        unlocked = false;
        unlockRequirement.OnUnlock += UnlockItem;
    }

    public virtual void BuyItem()
    {
        if(GameStats.Instance.Currency >= cost)
        {
            GameStats.Instance.Currency -= cost;
            shop.shopTiles.Remove(shopTile);
        }
    }
    public virtual void UnlockItem()
    {
        unlocked = true;
        shop.shopTiles.Add(shopTile);
        
        ShopTile addedShopTile = shop.shopTiles[shop.shopTiles.Count-1].GetComponent<ShopTile>();
        if(addedShopTile != null)
        {
            addedShopTile.shopItem = this;
            addedShopTile.shopItemIcon.sprite = shopItemIcon;
        }
    }

    public virtual int GetCost()
    {
        return cost;
    }
          
}
