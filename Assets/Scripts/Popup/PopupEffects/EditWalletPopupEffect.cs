using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditWalletPopupEffect : PopupEffect
{
    [SerializeField] int moneyEarned;

    public override void ExecutePopupEffect()
    {
        GameStats.Instance.Currency += moneyEarned;
    }
}
