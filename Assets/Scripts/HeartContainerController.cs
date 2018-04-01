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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
