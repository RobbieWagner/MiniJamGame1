using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGameManager : MonoBehaviour
{
    [SerializeField] private CurrencyMakerList currencyMakerList;
    [SerializeField] private Maintenance maintenance;
    [SerializeField] private Environment environment;

    bool started;

    private void Start()
    {
        started = false;
        maintenance.button.interactable = false;
        environment.button.interactable = false;
    }

    private void Update()
    {
        if(started)
        {
            if(maintenance.aboveZero)
            {
                environment.UpdateBar(Time.deltaTime, GameStats.Instance.environmentDeteriorationMultiplier);
                foreach(CurrencyMaker currencyMaker in currencyMakerList.currencyMakers)
                {
                    currencyMaker.UpdateCurrencyMaker(Time.deltaTime);
                }
                maintenance.UpdateBar(Time.deltaTime);
            }
        }

        else if(currencyMakerList.currencyMakers.Count > 0)
        {
            started = true;
            maintenance.button.interactable = true;
            environment.button.interactable = true;
        }
    }
}
