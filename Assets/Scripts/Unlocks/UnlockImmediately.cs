using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockImmediately : MonoBehaviour
{
    [SerializeField] private UnlockRequirement unlockRequirement;

    void Start()
    {
        if(!unlockRequirement.Unlocked) 
        {
            unlockRequirement.Unlocked = true;
        }
    }
}

