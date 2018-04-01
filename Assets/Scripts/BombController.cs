using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private GameManager gameManager;
	public GameObject explosion;
    // Use this for initialization
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (gameManager == null)
        {
            Debug.Log("Game manager not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
	private void OnMouseDown() {
		CameraShaker.Instance.ShakeOnce(8f, 4f,.1f,1f);
		Instantiate(explosion, transform.position,transform.rotation);
		gameManager.BombTapped();
		Destroy(gameObject);
	} 
}
