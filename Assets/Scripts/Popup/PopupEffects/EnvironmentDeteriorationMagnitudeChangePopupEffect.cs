using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentDeteriorationMagnitudeChangePopupEffect : PopupEffect
{
    [SerializeField] float changeMagnitude = 1f;

    public override void ExecutePopupEffect()
    {
        GameStats.Instance.CombineEnvironmentalMultiplier(changeMagnitude);
    }
}