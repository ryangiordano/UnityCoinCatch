using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {
	public Text FinalScore;
	// Use this for initialization
	void Start () {
		this.FinalScore.text = "Final Score: " +  StateManager.PlayerScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
