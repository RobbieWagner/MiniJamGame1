using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDisplay : MonoBehaviour
{

    public List<Popup> positivePopups;
    public List<Popup> negativePopups;
    [SerializeField] private CurrencyMakerList currencyMakerList;
    [SerializeField] private float percentChanceOfPopup;

    float negativePopupChance;

    // Start is called before the first frame update
    void Start()
    {
        GameStats.Instance.OnEarnedIncomesChange += RollForPopup;

        negativePopupChance = 50f;
    }

    public void ReduceNegativePopupChance(float difference)
    {
        negativePopupChance -= difference;
    }

    private void RollForPopup(int incomesEarned)
    {
        if(incomesEarned % currencyMakerList.currencyMakers.Count == 0)
        {
            bool displayAPopup = UnityEngine.Random.Range(0, 100) < percentChanceOfPopup;
            if(displayAPopup)
            {
                bool positivePopup = UnityEngine.Random.Range(0, 100) > negativePopupChance;
                if(positivePopup && positivePopups.Count > 0)
                {
                    int indexOfPopupToUse = (int) UnityEngine.Random.Range(0, positivePopups.Count);
                    Popup popupToUse = positivePopups[indexOfPopupToUse];

                    popupToUse.DisplayPopup();
                    positivePopups.Remove(popupToUse);
                }
                else if(!positivePopup && negativePopups.Count > 0)
                {
                    int indexOfPopupToUse = (int) UnityEngine.Random.Range(0, negativePopups.Count);
                    Popup popupToUse = negativePopups[indexOfPopupToUse];

                    popupToUse.DisplayPopup();
                    negativePopups.Remove(popupToUse);
                }
            }
        }
    }
}
