using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyMaker : MonoBehaviour
{
    [SerializeField] private float timerThreshold = 10f; 
    [SerializeField] private int incomeAmount = 10; 
    private float timer = 0f;
    [SerializeField] CurrencyMakerUI currencyMakerUI;

    void Awake()
    {
        currencyMakerUI.Initialize(timer, timerThreshold);
    }

    public virtual void UpdateCurrencyMaker(float timeIncrease)
    {
        timer += timeIncrease;

        if (timer >= timerThreshold)
        {
            timer -= timerThreshold;
            EarnIncome();
        }

        currencyMakerUI.UpdateCurrencyMakerUI(timer, timerThreshold);
    }

    private void EarnIncome()
    {
        // Add the incomeAmount to the player's currency in GameStats
        GameStats.Instance.EarnIncome(incomeAmount);
    }

    public void ChangeIncomeSpeed(float newTimerThreshold) {timerThreshold = newTimerThreshold;}
    public void ChangeIncomeAmount(int newIncomeAmount) {incomeAmount = newIncomeAmount;}
}
