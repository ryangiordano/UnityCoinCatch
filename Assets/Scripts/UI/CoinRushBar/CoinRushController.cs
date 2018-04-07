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

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetBar()
    {
        coinCombo = 0;
        var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
        var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
        iTween.ScaleTo(coinRushMeter,new Vector3(0,y,z),.5f);
        
    }
    public void IncrementMeter()
    {
        if (!coinRush && coinCombo < 10)
        {
            coinCombo++;
            var y = coinRushMeter.GetComponent<RectTransform>().localScale.y;
            var z = coinRushMeter.GetComponent<RectTransform>().localScale.z;
            iTween.ScaleTo(coinRushMeter,new Vector3((float)coinCombo/10,y,z),.5f);
  
        }

    }
}
