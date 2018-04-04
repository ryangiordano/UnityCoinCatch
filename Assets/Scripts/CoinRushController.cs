using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRushController : MonoBehaviour
{
    private int coinCombo;
    private bool coinRush = false;
    public GameObject coinRushBar;
    public GameObject coinRushMeter;
    private float barWidth;
    private float meterMaxWidth;
    // Use this for initialization
    void Start()
    {
        coinCombo = 0;
        var barSize = coinRushBar.GetComponent<RectTransform>().sizeDelta;
        barWidth = barSize.x;
        meterMaxWidth = barWidth - 20;
        Debug.Log(barSize);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetBar()
    {
        coinCombo = 0;
        var y = coinRushMeter.GetComponent<RectTransform>().sizeDelta.y;
        coinRushMeter.GetComponent<RectTransform>().sizeDelta = new Vector2(0, y);
    }
    public void IncrementMeter()
    {
        if (!coinRush && coinCombo < 10)
        {
            coinCombo++;
            var y = coinRushMeter.GetComponent<RectTransform>().sizeDelta.y;
            coinRushMeter.GetComponent<RectTransform>().sizeDelta = new Vector2(coinCombo * meterMaxWidth / 10, y);
        }

    }
}
