using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleGameManager : MonoBehaviour
{
    [SerializeField] private CurrencyMakerList currencyMakerList;
    [SerializeField] private Maintenance maintenance;
    [SerializeField] private Environment environment;

    [SerializeField] private float gameSpeed = 1f;

    bool started;

    public static IdleGameManager Instance {get; private set;}

    private void Start()
    {
        started = false;
        maintenance.button.interactable = false;
        environment.button.interactable = false;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Update()
    {
        if(started)
        {
            if(maintenance.aboveZero)
            {
                environment.UpdateBar(Time.deltaTime * gameSpeed, GameStats.Instance.environmentDeteriorationMultiplier);
                foreach(CurrencyMaker currencyMaker in currencyMakerList.currencyMakers)
                {
                    currencyMaker.UpdateCurrencyMaker(Time.deltaTime * gameSpeed);
                }
                maintenance.UpdateBar(Time.deltaTime, GameStats.Instance.maintenanceMultiplier);
            }
        }

        else if(currencyMakerList.currencyMakers.Count > 0)
        {
            started = true;
            maintenance.button.interactable = true;
            environment.button.interactable = true;
        }
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("latest_score", GameStats.Instance.Currency);
        if(GameStats.Instance.Currency > PlayerPrefs.GetInt("high_score", 0));
        PlayerPrefs.SetInt("high_score", GameStats.Instance.Currency);

        SceneManager.LoadScene("GameOverScene");
    }
    public void EndGame(bool win)
    {
        if(win)
        {
            PlayerPrefs.SetInt("latest_score", GameStats.Instance.Currency);
            if(GameStats.Instance.Currency > PlayerPrefs.GetInt("high_score", 0));
            PlayerPrefs.SetInt("high_score", GameStats.Instance.Currency);

            SceneManager.LoadScene("Win");
        }
        else
        {
            PlayerPrefs.SetInt("latest_score", GameStats.Instance.Currency);
            if(GameStats.Instance.Currency > PlayerPrefs.GetInt("high_score", 0));
            PlayerPrefs.SetInt("high_score", GameStats.Instance.Currency);

            SceneManager.LoadScene("GameOverScene");
        }
    }
}
