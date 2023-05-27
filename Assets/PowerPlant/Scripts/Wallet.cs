using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI walletText;

    // Start is called before the first frame update
    void Awake()
    {
        GameStats.Instance.OnCurrencyChange += UpdateWalletText;
        walletText.text = "Wallet: ...";
    }

    private void UpdateWalletText(int walletAmount)
    {
        walletText.text = "Wallet: " + walletAmount;
    }
}
