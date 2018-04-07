using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLerp : MonoBehaviour {
	public Transform StartScale;
	public Transform EndScale;
	float StartTime;
	float TotalDistanceToScaleDestination;
	// Use this for initialization
	void Start () {
		StartTime = Time.time;
		TotalDistanceToScaleDestination = Vector3.Distance(StartScale.localScale, EndScale.localScale);
	}
	
	// Update is called once per frame
	void Update () {
		//Need these two pieces of data before we can call Lerp.
		float currentDuration = Time.time - StartTime;//Gets larger the longer the code runs.
		float JourneyFraction = currentDuration / TotalDistanceToScaleDestination;
		transform.localScale = Vector3.Lerp(StartScale.localScale,EndScale.localScale, JourneyFraction);

	}
}
