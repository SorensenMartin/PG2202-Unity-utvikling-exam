using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health;
	public int maxHealth = 10;
	public int fuel;
	public int maxFuel = 1500;
    public int money;
	
	public GameManager gameManager;
	public GameObject SpaceShip;


	void Start()
    {
		Debug.Log("Start Player");
		health = 10;
		fuel = 1000;
		Debug.Log("Health set to " + health);
		Debug.Log("Fuel set to " + fuel);

	}
	
	
	void Update()
    {
		//check if spaceship moves
		
		
		//while (SpaceShip.transform.position.x > SpaceShip.)
		//{
			if (Time.frameCount % 500 == 0)
			{
				fuel -= 10;
			}
			if (fuel <= 0)
			{
				gameManager.EndGame();
			}
		//}
	}
	
	public void ReciveDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			gameManager.EndGame();
		}
	}

	void OnCollisionEnter(Collision collider)
	{
		ReciveDamage(1);
		Debug.Log("Desert Rider got hit!");
    }
}
