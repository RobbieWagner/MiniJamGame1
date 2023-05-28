using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentChangePopupEffect : PopupEffect
{
    [SerializeField] float changeMagnitude = 3000;
    [SerializeField] Environment environment;

    public override void ExecutePopupEffect()
    {
        Debug.Log("hi");
        environment.ChangeEnvironmentValue(changeMagnitude);
    }
}
