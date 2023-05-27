using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGameManager : MonoBehaviour
{
    [SerializeField] private CurrencyMakerList currencyMakerList;

    private void Start()
    {
        // Initialize the game
        InitializeGame();
    }

    private void Update()
    {
        // Update the currency makers
        foreach(CurrencyMaker currencyMaker in currencyMakerList.currencyMakers)
        {
            currencyMaker.UpdateCurrencyMaker(Time.deltaTime);
        }

        // update other things as necessary
    }

    private void InitializeGame()
    {
        // Set up the store, load player's currency, etc.s
    }

}
