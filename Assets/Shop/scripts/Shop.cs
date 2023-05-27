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

    public void DisplayShop()
    {
        foreach(GameObject tile in displayedShopTiles)
        {
            Destroy(tile);
        }
        displayedShopTiles.Clear();

        float posX = minTilePositionX;
        float posY = maxTilePositionY;

        foreach(GameObject shopTileGO in shopTiles)
        {
            ShopTile shopTile = shopTileGO.GetComponent<ShopTile>();

            if(shopTile != null)
            {
                displayedShopTiles.Add(Instantiate(shopTileGO, this.transform));
                RectTransform rect = shopTileGO.GetComponent<RectTransform>();

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
}
