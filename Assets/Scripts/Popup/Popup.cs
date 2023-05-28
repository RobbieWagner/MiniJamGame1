using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Canvas popupCanvas;
    [SerializeField] private UnlockRequirement unlockRequirement;
    [SerializeField] private PopupDisplay popupDisplay;

    [SerializeField] bool positivePopup;

    [SerializeField] PopupEffect[] popupEffects;

    void Awake()
    {
        popupCanvas.enabled = false;
        unlockRequirement.OnUnlock += UnlockPopup;
    }

    private void UnlockPopup()
    {
        if(positivePopup && !popupDisplay.positivePopups.Contains(this)) popupDisplay.positivePopups.Add(this);
        else if(!positivePopup && !popupDisplay.negativePopups.Contains(this)) popupDisplay.negativePopups.Add(this);
    }

    public void DisplayPopup()
    {
        popupCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void RemovePopup()
    {
        popupCanvas.enabled = false;
        Time.timeScale = 1f;
        foreach(PopupEffect popupEffect in popupEffects) popupEffect.ExecutePopupEffect();
    }
}
