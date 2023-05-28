using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Environment : MonoBehaviour
{
[SerializeField] private float timerThreshold = 300000f;
    [SerializeField] Slider slider;
    [HideInInspector] public bool aboveZero;

    [SerializeField] int costOfReplenishment;
    [SerializeField] TextMeshProUGUI costText;

    public Button button;
    public Button finishGame;

    void Awake()
    {
        slider.minValue = 0;
        slider.maxValue = timerThreshold;
        slider.value = timerThreshold;

        aboveZero = true;

        costText.text = "Replenish(M$" + costOfReplenishment + ")";

        finishGame.gameObject.SetActive(false);
    }

    private void Update() 
    {
        if(!aboveZero) IdleGameManager.Instance.EndGame();
    }

    public void UpdateBar(float timeDifference, float environmentDeteriorationMultiplier)
    {
        slider.value -= timeDifference * environmentDeteriorationMultiplier;

        if(slider.value <= 0)
        aboveZero = false; 
    }

    public void ChangeEnvironmentValue(float magnitude)
    {
        Debug.Log("hello");
        slider.value += magnitude;

        if(slider.value <= 0)
        aboveZero = false;
    }

    public void ReplenishBar()
    {
        if(GameStats.Instance.Currency >= costOfReplenishment)
        {
            GameStats.Instance.Currency -= costOfReplenishment;
            slider.value += slider.maxValue/4;
            aboveZero = true;

            if(costOfReplenishment * 2 < 2000000000) 
            {
                costOfReplenishment *= 2;
                costText.text = "Replenish(M$" + costOfReplenishment + ")";
            }
            else
            {
                button.enabled = false;
                costText.text = "";
                finishGame.gameObject.SetActive(true);
            }
        }
    }

    public void FinishGame()
    {
        IdleGameManager.Instance.EndGame(true);
    }
}
