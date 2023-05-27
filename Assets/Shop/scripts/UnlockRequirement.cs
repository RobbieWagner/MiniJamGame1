using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockRequirement: MonoBehaviour
{
    public bool Unlocked
    {
        get {return unlocked;}
        set
        {
            if(!value) return;
            unlocked = true;
            if(OnUnlock != null) OnUnlock();
        }
    }
    private bool unlocked = false;

    public delegate void OnUnlockDelegate();
    public event OnUnlockDelegate OnUnlock;
}
