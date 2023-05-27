using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<GameObject> shopTiles;
    public List<GameObject> displayedShopTiles;

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

        foreach(GameObject shopTileGO in shopTiles)
        {
            ShopTile shopTile = shopTileGO.GetComponent<ShopTile>();

            if(shopTile != null)
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
        }
    }

    public void RemoveItem(GameObject item)
    {
        int index = shopTiles.IndexOf(item);
        Destroy(displayedShopTiles[index]);
        shopTiles.Remove(item);
    }
}
