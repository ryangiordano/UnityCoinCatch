using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainerController : MonoBehaviour {
	public GameObject Heart;
	public List<GameObject> Hearts;

	private int CurrentHealth;
	public int MaxHealth;
	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		DrawHearts();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void DrawHearts(){
		float x = -70;
        Quaternion spawnRotation = Quaternion.identity;
		
		for(int i =0; i<MaxHealth; i++){
			Debug.Log("Drawing hearts.");
			var heart = Instantiate(Heart,new Vector3(x,0,0), spawnRotation, this.gameObject.transform);
			var transform = heart.GetComponent<RectTransform>();
			transform.localPosition = new Vector3(x,0,0);
			x +=50;
		}
	}
}
