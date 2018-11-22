using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OutroController : MonoBehaviour {
	
	
	public TextMesh infoText;	

	// Use this for initialization
	void Start () {
		infoText.text = "You finished the game with a score of: " + PlayerStats.instance.gameScore;
		
		
		
		float timeToLoadScene = 5;
		Invoke("GoToIntroScene", timeToLoadScene);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
		{
			PlayerStats.instance.gameScore = 0;
			SceneManager.LoadScene("Game");
		}
		
	}
	
	void GoToIntroScene(){
		SceneManager.LoadScene("Intro");
	}
	
	
}
