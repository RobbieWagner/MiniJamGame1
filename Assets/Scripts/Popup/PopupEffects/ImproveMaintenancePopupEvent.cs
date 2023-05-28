using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaintenancePopupEvent : PopupEffect
{
    [SerializeField] float changeMagnitude;
    [SerializeField] Maintenance maintenance;

    public override void ExecutePopupEffect()
    {
        maintenance.IncreaseThreshold(changeMagnitude);
    }
}
