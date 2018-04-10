using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;

public class CoinRushController : MonoBehaviour
{
    private bool coinRush = false;
    private bool superCoinRush = false;
    private bool bonusActive;
    public GameObject coinRushBar;
    public GameObject coinRushMeter;
    public GameObject twoTimesMultiplier;
    public GameObject superCoinRushMeter;
    public GameObject fourTimesMultiplier;
    public GameObject shockWave;
    public GameObject sparkle;
    private float barWidth;
    private float meterMaxWidth;
    // Use this for initialization
    void Start()
    {
        StateManager.CoinStreak = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinRush && !bonusActive)
        {
            CoinRushActive(2);
        }
        if(coinRush && superCoinRush){
            SuperCoinRushActive();
        }
    }

    public void CoinRushActive(int bonus)
    {
        bonusActive = true;
        twoTimesMultiplier.SetActive(true);
        BonusMultiplier.SetMultiplierAmount(bonus);
        coinRushMeter.GetComponent<Animator>().SetBool("CoinRush", true);
    }
    public void SuperCoinRushActive(){
        twoTimesMultiplier.SetActive(false);
        fourTimesMultiplier.SetActive(true);
        CoinRushActive(4);
        superCoinRushMeter.GetComponent<Animator>().SetBool("SuperCoinRush",true);
        
    }
    public void FlashGreen()
    {

    }
    public void CoinRushInactive()
    {
        coinRush = false;
        superCoinRush =false;
        BonusMultiplier.ResetMultiplierAmount();
        bonusActive = false;
        twoTimesMultiplier.SetActive(false);
        fourTimesMultiplier.SetActive(false);
        coinRushMeter.GetComponent<Animator>().SetBool("CoinRush", false);
        superCoinRushMeter.GetComponent<Animator>().SetBool("SuperCoinRush", false);
    }
    public IEnumerator ResetBar()
    {
        StateManager.CoinStreak = 0;
        var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
        var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
        iTween.ScaleTo(superCoinRushMeter, new Vector3(0, y, z), .5f);
        CoinRushInactive();
        
        yield return new WaitForSeconds(.5f);
        iTween.ScaleTo(coinRushMeter, new Vector3(0, y, z), .5f);
        
        

    }
    public void IncrementMeter()
    {
        if (!coinRush && StateManager.CoinStreak < 10)
        {
            StateManager.CoinStreak++;
            var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
            var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
            iTween.ScaleTo(coinRushMeter, new Vector3((float)StateManager.CoinStreak / 10, y, z), .5f);
            if (StateManager.CoinStreak >= 10)
            {
                coinRush = true;
            }
        }else if(coinRush && StateManager.CoinStreak<20){
            StateManager.CoinStreak++;
            var y = superCoinRushMeter.GetComponent<RectTransform>().localScale.y;
            var z = superCoinRushMeter.GetComponent<RectTransform>().localScale.z;
            iTween.ScaleTo(superCoinRushMeter, new Vector3((float)(StateManager.CoinStreak-10)/ 10, y, z), .5f);
            if (StateManager.CoinStreak >= 20)
            {
                superCoinRush = true;
            }
        }

    }
}
