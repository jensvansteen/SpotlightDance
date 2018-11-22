using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public Player player;
	public GameObject enemyPrefab;
	public TextMesh infoText;	
	
	public float enemySpawnDistance = 20f;

	public float enemyInterval = 2.0f;
	public float minimumEnemyInterval = 0.5f;
	public float enemyIntervalDecrement = 0.1f;

	private float gameTimer = 20f;
	private float enemyTimer = 0f;
	private float resetTimer = 3f;
	public int gameScore = 0;

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{


		gameTimer -= Time.deltaTime;
		if (gameTimer > 0f)
		{
			infoText.text = "Hit all the enemies!\n Time: " + Math.Floor(gameTimer) + "\nScore: " + PlayerStats.instance.gameScore;
		}
		else
		{
			SceneManager.LoadScene("Outro");
		}
		
		
		/*if (player.health > 0)
		{
			gameTimer += Time.deltaTime;
			infoText.text = "Health:" + player.health;
			infoText.text += "\nTime: " + Mathf.Floor(gameTimer);
		}
		else
		{
			infoText.text = "Game over!";
			infoText.text += "You survived for" + Math.Floor(gameTimer) + "seconds";

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f)
			{
				SceneManager.LoadScene("OcolusBuild");
			}
		}*/
		
	
		/*Spawning of enemys na een bepaalde tijd.*/
		enemyTimer -= Time.deltaTime;
		if (enemyTimer <= 0)
		{
			enemyTimer = enemyInterval;
			enemyInterval -= enemyIntervalDecrement;
			if (enemyInterval < minimumEnemyInterval)
			{
				enemyInterval = minimumEnemyInterval;
			}
			GameObject enemyObject = Instantiate(enemyPrefab);
			Enemy enemy = enemyObject.GetComponent<Enemy>();
			// 

			float randomAngle = Random.Range(0f, Mathf.PI);
			enemy.transform.position = new Vector3(player.transform.position.x + Mathf.Cos(randomAngle) * enemySpawnDistance, enemy.transform.position.y, player.transform.position.z + Mathf.Sin(randomAngle) * enemySpawnDistance);
			enemy.player = player;
			enemy.direction = (player.transform.position - enemy.transform.position).normalized;
		}
		

		
	}
}
