using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour {
	private Rigidbody rigidbody;
	public float thrust;
	public float tumble;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.AddForce(0,thrust,0,ForceMode.Impulse);
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
	}
}
