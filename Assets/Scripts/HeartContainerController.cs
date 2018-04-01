using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainerController : MonoBehaviour {
	public GameObject Heart;
	public List<GameObject> Hearts;

	public int CurrentHealth;
	public int MaxHealth;
	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		DrawHearts();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RemoveHeart(){
		var heartList = new List<Transform>();
		if(transform.childCount> 0){
			foreach(Transform child in transform){
				if(child.CompareTag("Heart")){
					heartList.Add(child);
				}
			}
			Debug.Log(heartList[heartList.Count-1]);
			var heart = heartList[heartList.Count-1].GetComponent<HeartController>();
			Debug.Log(heart);
			heart.HeartExplode();
			CurrentHealth--;
		}
	}
	private void DrawHearts(){
		float x = -70;
        Quaternion spawnRotation = Quaternion.identity;
		
		for(int i =0; i<MaxHealth; i++){
			var heart = Instantiate(Heart,new Vector3(x,0,0), spawnRotation, this.gameObject.transform);
			var transform = heart.GetComponent<RectTransform>();
			transform.localPosition = new Vector3(x,0,0);
			x +=50;
		}
	}
}
