using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int damage = 3;
	public float speed = 3.5f;
	public float distanceToStop = 1f;
	public Vector3 direction;
	public Player player;

	public bool chasingPlayer = true;

	public float eatingInterval = 0.5f;
	private float eatingTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Checjt de afstand tussen de player en de enemy, als het minder is als distancetoStop gaat het stoppem net chasen
		if (Vector3.Distance(transform.position, player.transform.position) < distanceToStop)
		{
			chasingPlayer = false;
		}
		
		
		if (chasingPlayer)
		{
			transform.position += direction * speed * Time.deltaTime;
		}
		else
		{
			eatingTimer -= Time.deltaTime;
			if (eatingTimer <= 0f)
			{
				eatingTimer = eatingInterval;
				player.health -= damage;
			}
		}
	}
}
