using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;

public class CoinRushController : MonoBehaviour
{
    private int coinCombo;
    private bool coinRush = false;
    private bool bonusActive;
    public GameObject coinRushBar;
    public GameObject coinRushMeter;
    public GameObject twoTimesMultiplier;
    public GameObject fourTimesMultiplier;
    private float barWidth;
    private float meterMaxWidth;
    // Use this for initialization
    void Start()
    {
        coinCombo = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(coinRush && !bonusActive){
            bonusActive = true;
            twoTimesMultiplier.SetActive(true);
            BonusMultiplier.SetMultiplierAmount(2);

        }
    }
    public void ResetBar()
    {
        coinCombo = 0;
        var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
        var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
        iTween.ScaleTo(coinRushMeter,new Vector3(0,y,z),.5f);
        coinRush = false;
        BonusMultiplier.ResetMultiplierAmount();
        bonusActive =false;
        twoTimesMultiplier.SetActive(false);
        
    }
    public void IncrementMeter()
    {
        if (!coinRush && coinCombo < 10)
        {
            coinCombo++;
            var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
            var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
            iTween.ScaleTo(coinRushMeter,new Vector3((float)coinCombo/10,y,z),.5f);
            if(coinCombo>=10){
                coinRush = true;
            }
        }

    }
}
