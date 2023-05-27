using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithIncomes : MonoBehaviour
{

    [SerializeField] private int incomeRequirement;
    [SerializeField] private UnlockRequirement unlockRequirement;

    void Awake()
    {
        GameStats.Instance.OnEarnedIncomesChange += FulfillUnlockrequirement;
    }

    private void FulfillUnlockrequirement(int incomesEarned)
    {
        if(incomesEarned == incomeRequirement)unlockRequirement.Unlocked = true;
    }
}
