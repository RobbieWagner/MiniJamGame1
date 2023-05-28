using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() 
    {
        scoreText.text = "<color=green>High Score: " + PlayerPrefs.GetInt("high_score", 0).ToString();
    }
}
