using System.Collections;
using System.Collections.Generic;
using Coin_Catch.Assets.Scripts.utility;
using UnityEngine;

public class CoinRushController : MonoBehaviour
{
    private bool coinRush = false;
    private bool bonusActive;
    public GameObject coinRushBar;
    public GameObject coinRushMeter;
    public GameObject twoTimesMultiplier;
    // public GameObject fourTimesMultiplier;
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
    }

    public void CoinRushActive(int bonus)
    {
        bonusActive = true;
        twoTimesMultiplier.SetActive(true);
        BonusMultiplier.SetMultiplierAmount(bonus);
        coinRushMeter.GetComponent<Animator>().SetBool("CoinRush", true);
    }
    public void FlashGreen()
    {

    }
    public void CoinRushInactive()
    {
        coinRush = false;
        BonusMultiplier.ResetMultiplierAmount();
        bonusActive = false;
        twoTimesMultiplier.SetActive(false);
        coinRushMeter.GetComponent<Animator>().SetBool("CoinRush", false);
    }
    public void ResetBar()
    {
        StateManager.CoinStreak = 0;
        var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
        var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
        iTween.ScaleTo(coinRushMeter, new Vector3(0, y, z), .5f);
        CoinRushInactive();

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
        }

    }
}
