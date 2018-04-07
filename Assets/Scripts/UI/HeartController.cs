using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour {
	public Animator animator;
	public ShrinkBehavior shrinkBehavior;
	public bool shrinking;
	public bool exploded;
	public GameObject heartExplode;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		shrinkBehavior = animator.GetBehaviour<ShrinkBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
		if(shrinkBehavior.Finished && !exploded){
			HeartExplode();
		}
	}
	public void ShrinkHeart(){
		shrinking=true;
		animator.SetTrigger("LossHeart");
		
		
	}
	public void HeartExplode(){
		exploded=true;
		var pos = transform.localPosition;
		
		pos.y = 0;
		var explosion = Instantiate(heartExplode,transform.localPosition,transform.localRotation,transform.parent);
		var newTransform = explosion.GetComponent<Transform>();

		newTransform.localPosition = transform.localPosition;
		
		Destroy(gameObject);
		
	}
}
