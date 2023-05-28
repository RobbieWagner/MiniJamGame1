using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<GameObject> shopTiles;
    public List<GameObject> displayedShopTiles;
    private List<GameObject> purchasedShopTiles;

    [SerializeField] private float minTilePositionX;
    [SerializeField] private float maxTilePositionX;
    [SerializeField] private float minTilePositionY;
    [SerializeField] private float maxTilePositionY;

    [SerializeField] private float distanceBetweenTilesX;
    [SerializeField] private float distanceBetweenTilesY;

    [SerializeField] Canvas canvas;

    bool shopDisplayed;

    private void Start() 
    {
        shopDisplayed = false;
        purchasedShopTiles = new List<GameObject>();
    }

    private void Update()
    {
        if(!shopDisplayed)
        {
            shopDisplayed = true;
            DisplayShop();
        }
    }

    public void DisplayShop()
    {
        foreach(GameObject tile in displayedShopTiles)
        {
            Destroy(tile);
        }
        displayedShopTiles.Clear();

        shopTiles.Distinct().ToList();

        float posX = minTilePositionX;
        float posY = maxTilePositionY;

        for(int j = 0; j < shopTiles.Count; j++)
        {
            GameObject shopTileGO = shopTiles[j];
            ShopTile shopTile = shopTileGO.GetComponent<ShopTile>();

            bool shopTileThere = false;
            for(int i = 0; i < displayedShopTiles.Count; i++)
            {
                ShopTile displayShopTile = displayedShopTiles[i].GetComponent<ShopTile>();

                if(displayShopTile.shopItemIcon.sprite == shopTile.shopItemIcon.sprite) shopTileThere = true;
            }
            if(purchasedShopTiles != null)
            {
                for(int i = 0; i < purchasedShopTiles.Count; i++)
                {
                    ShopTile purchasedTile = purchasedShopTiles[i].GetComponent<ShopTile>();

                    if(purchasedTile.shopItemIcon.sprite == shopTile.shopItemIcon.sprite) shopTileThere = true;
                }
            }

            if(shopTile != null && !shopTileThere)
            {
                displayedShopTiles.Add(Instantiate(shopTileGO, this.transform));
                RectTransform rect = displayedShopTiles[displayedShopTiles.Count - 1].GetComponent<RectTransform>();

                rect.anchoredPosition = new Vector2(posX, posY);
                posX += distanceBetweenTilesX;
                if(posX > maxTilePositionX)
                {
                    posX = minTilePositionX;
                    posY -= distanceBetweenTilesY;
                }

                //Debug.Log("X" + posX + " Y" + posY);
            }
            else if(shopTile != null && shopTileThere)
            {
                shopTiles.RemoveAt(j);
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        int index = shopTiles.IndexOf(item);

        if(index < shopTiles.Count)
        {
            purchasedShopTiles.Add(shopTiles[index]);
            Destroy(displayedShopTiles[index]);
            shopTiles.Remove(item);
        }
    }
}
