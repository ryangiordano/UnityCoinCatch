using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	public int score;
	
	private GameManager gameManager;
	public GameObject sparkle;
	// Use this for initialization
	void Start () {
		GameObject gameManagerObject =  GameObject.FindWithTag("GameController");
		if(gameManagerObject !=null){
			gameManager = gameManagerObject.GetComponent<GameManager>();
		}
		if(gameManager ==null){
			Debug.Log("Game manager not found.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnMouseDown() {
		gameManager.IncrementScore(score);
		Instantiate(sparkle, transform.position,transform.rotation);
		Destroy(gameObject);
	} 

}
