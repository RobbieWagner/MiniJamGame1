using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditWalletPopupEffect : PopupEffect
{
    [SerializeField] float moneyMultiplier;

    public override void ExecutePopupEffect()
    {
        GameStats.Instance.MultiplyMoney(moneyMultiplier);
    }
}
