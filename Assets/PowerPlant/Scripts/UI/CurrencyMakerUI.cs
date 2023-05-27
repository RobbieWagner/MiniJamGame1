using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyMakerUI : MonoBehaviour
{

    [SerializeField] private Slider timerProgress;

    public void Initialize(float timer, float timerThreshold)
    {
        timerProgress.minValue = 0;
        timerProgress.maxValue = timerThreshold;
        timerProgress.value = timer;
    }

    public void UpdateCurrencyMakerUI(float timer, float timerThreshold)
    {
        timerProgress.value = timer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
