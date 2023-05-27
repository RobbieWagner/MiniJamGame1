using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDisplay : MonoBehaviour
{

    public List<Popup> popups;
    [SerializeField] private CurrencyMakerList currencyMakerList;
    [SerializeField] private float percentChanceOfPopup;

    // Start is called before the first frame update
    void Start()
    {
        GameStats.Instance.OnEarnedIncomesChange += RollForPopup;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RollForPopup(int incomesEarned)
    {
        if(incomesEarned % currencyMakerList.currencyMakers.Count == 0)
        {
            bool displayAPopup = UnityEngine.Random.Range(0, 100) < percentChanceOfPopup;
            if(displayAPopup && popups.Count > 0)
            {
                int indexOfPopupToUse = (int) UnityEngine.Random.Range(0, popups.Count);
                Popup popupToUse = popups[indexOfPopupToUse];

                popupToUse.DisplayPopup();
                popups.Remove(popupToUse);
            }
        }
    }
}
