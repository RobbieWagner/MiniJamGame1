using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance {get; private set;}

    public float environmentDeteriorationMultiplier = 1f;
    public int Currency
    {
        get {return currency;}
        set
        {
            if(value == currency) return;
            currency = value;
            if(OnCurrencyChange != null) OnCurrencyChange(currency); 
        }
    }
    [SerializeField] private int currency;

    public delegate void OnCurrencyChangeDelegate(int newValue);
    public event OnCurrencyChangeDelegate OnCurrencyChange;

    
    public int IncomesEarned
    {
        get{return incomesEarned;}
        set
        {
            if(value == 0) return;
            incomesEarned = value;
            if(OnEarnedIncomesChange != null) OnEarnedIncomesChange(incomesEarned);
        }
    }
    private int incomesEarned;

    public delegate void OnEarnedIncomesChangeDelegate(int newValue);
    public event OnEarnedIncomesChangeDelegate OnEarnedIncomesChange;

    private void Awake() 
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

    public void EarnIncome(int incomeAmount)
    {
        UpdateCurrency(incomeAmount);

        IncomesEarned++;
    }

    private void UpdateCurrency(int incomeAmount)
    {
        Currency += incomeAmount;
    }

    public void CombineEnvironmentalMultiplier(float multiplier)
    {
        environmentDeteriorationMultiplier *= multiplier;
    }
}
