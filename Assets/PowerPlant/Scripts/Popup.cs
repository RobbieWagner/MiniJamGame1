using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Canvas popupCanvas;
    [SerializeField] private int incomesToTrigger = 3;

    void Awake()
    {
        popupCanvas.enabled = false;
        GameStats.Instance.OnEarnedIncomesChange += CheckForPopup;
    }

    private void CheckForPopup(int earnedIncomes)
    {
        if(earnedIncomes == incomesToTrigger)
        DisplayPopup();
    }

    private void DisplayPopup()
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
