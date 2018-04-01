using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {

	public GameObject heartExplode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void HeartExplode(){
		var pos = transform.localPosition;
		pos.y = 0;
		var explosion = Instantiate(heartExplode,transform.localPosition,transform.localRotation,transform.parent);
		var newTransform = explosion.GetComponent<Transform>();
		newTransform.localPosition = transform.localPosition;
		Destroy(gameObject);
		
	}
}
