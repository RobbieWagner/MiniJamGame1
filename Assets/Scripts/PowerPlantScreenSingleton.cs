using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantScreenSingleton : MonoBehaviour
{
    public Canvas canvas;
    public static PowerPlantScreenSingleton Instance {get; private set;}

    [SerializeField] CurrencyMakerList currencyMakerList;

    float[,,] displayPosition;

    void Awake()
    {
        displayPosition = new float[,,]   {{{0,0},{0,0},{0,0},{0,0},{0,0},{0,0}},
                                        {{-90,0},{90,0},{0,0},{0,0},{0,0},{0,0}},
                                        {{-120,0},{0,0},{120,0},{0,0},{0,0},{0,0}},
                                        {{-90,90},{90,90},{-90,-90},{90,-90},{0,0},{0,0}},
                                        {{-90,90},{90,90},{-120,-90},{0,-90},{120,-90},{0,0}},
                                        {{-120,90},{0,90},{120,90},{-120,-90},{0,-90},{120,-90}}};

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public CurrencyMaker AddPlant(GameObject plant)
    {
        CurrencyMaker currencyMaker = plant.GetComponent<CurrencyMaker>();
        if(currencyMaker != null)
        {
            GameObject newPlant = Instantiate(plant, this.transform);
            RectTransform plantT = newPlant.GetComponent<RectTransform>();
            currencyMakerList.currencyMakers.Add(newPlant.GetComponent<CurrencyMaker>());
        }
        return currencyMaker;
    }

    public void RemovePlant(int index)
    {
        GameObject plant = currencyMakerList.currencyMakers[index].gameObject;
        Destroy(plant);
        currencyMakerList.currencyMakers.RemoveAt(index);
    }

    public void DisplayPlants()
    {
        List<CurrencyMaker> currencyMakers = currencyMakerList.currencyMakers;

        int index = currencyMakers.Count - 1;

        for(int i = 0; i < currencyMakers.Count; i++)
        {
            currencyMakers[i].transform.localPosition = new Vector2(displayPosition[index,i,0], displayPosition[index,i,1]);
        }
    }
}
