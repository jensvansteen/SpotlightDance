using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroController : MonoBehaviour {
	
	
	public TextMesh infoText;	

	// Use this for initialization
	void Start () {
		
		infoText.text = "Dit is de intro";
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1"))
		{
			PlayerStats.instance.gameScore = 0;
			SceneManager.LoadScene("Game");
		}
		
	}
}

