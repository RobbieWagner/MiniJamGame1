using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Canvas popupCanvas;
    [SerializeField] private UnlockRequirement unlockRequirement;
    [SerializeField] private PopupDisplay popupDisplay;

    void Awake()
    {
        popupCanvas.enabled = false;
        unlockRequirement.OnUnlock += UnlockPopup;
    }

    private void UnlockPopup()
    {
        if(!popupDisplay.popups.Contains(this)) popupDisplay.popups.Add(this);
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
    }
}
