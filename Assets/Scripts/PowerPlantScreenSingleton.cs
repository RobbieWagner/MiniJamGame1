using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantScreenSingleton : MonoBehaviour
{
    public Canvas canvas;
    public static PowerPlantScreenSingleton Instance {get; private set;}

    [SerializeField] CurrencyMakerList currencyMakerList;

    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void AddPlant(GameObject plant)
    {
        CurrencyMaker currencyMaker = plant.GetComponent<CurrencyMaker>();
        if(currencyMaker != null)
        {
            GameObject newPlant = Instantiate(plant, this.transform);
            RectTransform plantT = newPlant.GetComponent<RectTransform>();
            currencyMakerList.currencyMakers.Add(newPlant.GetComponent<CurrencyMaker>());
        }
    }

    public void RemovePlant(int index)
    {
        GameObject plant = currencyMakerList.currencyMakers[index].gameObject;
        Destroy(plant);
        currencyMakerList.currencyMakers.RemoveAt(index);
    }
}
