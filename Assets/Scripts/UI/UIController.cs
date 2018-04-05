using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	public Button backButton;
	// Use this for initialization
	void Start () {
		var btn = backButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void TaskOnClick() {
        SceneManager.LoadScene("Main");

	} 
}
