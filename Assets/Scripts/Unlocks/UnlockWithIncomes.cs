using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWithIncomes : MonoBehaviour
{

    [SerializeField] private int incomeRequirement;
    [SerializeField] private UnlockRequirement unlockRequirement;

    void Awake()
    {
        GameStats.Instance.OnEarnedIncomesChange += FulfillUnlockRequirement;
    }

    private void FulfillUnlockRequirement(int incomesEarned)
    {
        if(incomesEarned == incomeRequirement)unlockRequirement.Unlocked = true;
    }
}
