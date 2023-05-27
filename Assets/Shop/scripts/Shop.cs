using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<GameObject> shopTiles;
    public List<GameObject> displayedShopTiles;
    [SerializeField] private int columns;
    
    public void DisplayShop()
    {
        foreach(GameObject tile in displayedShopTiles)
        {
            Destroy(tile);
        }
        displayedShopTiles.Clear();

        foreach(GameObject shopTileGO in shopTiles)
        {
            ShopTile shopTile = shopTileGO.GetComponent<ShopTile>();

            if(shopTile != null)
            {
                displayedShopTiles.Add(Instantiate(shopTileGO, this.transform));
            }
        }
    }
}
