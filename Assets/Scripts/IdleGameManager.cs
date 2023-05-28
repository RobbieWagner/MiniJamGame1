using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGameManager : MonoBehaviour
{
    [SerializeField] private CurrencyMakerList currencyMakerList;
    [SerializeField] private Maintenance maintenance;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(maintenance.aboveZero)
        {
            foreach(CurrencyMaker currencyMaker in currencyMakerList.currencyMakers)
            {
                currencyMaker.UpdateCurrencyMaker(Time.deltaTime);
            }
            maintenance.UpdateBar(Time.deltaTime);
        }
    }
}
