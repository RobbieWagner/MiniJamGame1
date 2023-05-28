using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() 
    {
        scoreText.text = "<color=green>Final Score: " + PlayerPrefs.GetInt("latest_score", 0).ToString();
    }
}
