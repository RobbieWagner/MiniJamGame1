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

    void Awake()
    {
        slider.minValue = 0;
        slider.maxValue = timerThreshold;
        slider.value = timerThreshold;

        aboveZero = true;

        costText.text = "Replenish(M$" + costOfReplenishment + ")";
    }

    private void Update() 
    {
        if(!aboveZero) SceneManager.LoadScene("MainMenu");
    }

    public void UpdateBar(float timeDifference, float environmentDeteriorationMultiplier)
    {
        slider.value -= timeDifference * environmentDeteriorationMultiplier;

        if(slider.value <= 0)
        aboveZero = false; 
    }

    public void ReplenishBar()
    {
        if(GameStats.Instance.Currency >= costOfReplenishment)
        {
            GameStats.Instance.Currency -= costOfReplenishment;
            slider.value += 10000;
            aboveZero = true;

            costOfReplenishment *= 2;
            costText.text = "Replenish(M$" + costOfReplenishment + ")";
        }
    }
}
