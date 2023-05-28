using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maintenance : MonoBehaviour
{
    
    [SerializeField] private float timerThreshold = 30f;
    [SerializeField] Slider slider;
    [HideInInspector] public bool aboveZero;

    public Button button;

    void Awake()
    {
        slider.minValue = 0;
        slider.maxValue = timerThreshold;
        slider.value = timerThreshold;

        aboveZero = true;
    }

    public void UpdateBar(float timeDifference)
    {
        slider.value -=timeDifference;

        if(slider.value <= 0)
        aboveZero = false; 
    }

    public void ReplenishBar()
    {
        slider.value = slider.maxValue;
        aboveZero = true;
    }

    public void IncreaseThreshold(float amount)
    {
        slider.maxValue += amount;
        slider.value += amount;
    }
}
