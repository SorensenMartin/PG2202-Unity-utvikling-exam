using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

	public int health;
	public int maxHealth = 10;
	public int fuel;
	public int maxFuel = 1500;
	public int money;
	public int packages;
	private GameObject collidedPackage;
	

	public GameManager gameManager;
	public GameObject SpaceShip;
	public GameObject PickUpPackage;
	public GameObject QuestIcon;

	public bool mechanicalEngine = false;
	public bool boostUpgrade = false;

	public TextMeshProUGUI packageCountTxt;

	void Start()
	{
		//Sets the players stats
		Debug.Log("Start Player");
		health = 10;
		fuel = 1000;
		Debug.Log("Health set to " + health);
		Debug.Log("Fuel set to " + fuel);
	}


	void Update()
	{
		//decreses fuel after a set amount of time
		if (Time.frameCount % 500 == 0)
		{
			fuel -= 10;
		}
		if (fuel <= 0)
		{
			gameManager.EndGame();
		}

		//picks up packages from the ground using the space key
		if (Input.GetKeyDown(KeyCode.Space) && PickUpPackage.activeSelf == true)
		{
			packages += 1;
			PickUpPackage.SetActive(false);
			Destroy(collidedPackage);
			collidedPackage = null;
			QuestIcon.SetActive(false);
		}
		packageCountTxt.text = packages.ToString();
	}

	//recives damage from the enemy
	public void ReciveDamage(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			gameManager.EndGame();
		}
	}
	//Check for collision with the enemy bullet in this case
	void OnCollisionEnter(Collision collider)
	{
		ReciveDamage(1);
		Debug.Log("Desert Rider got hit!");
	}
	//Check if you fly over a package
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Package"))
		{
			PickUpPackage.SetActive(true);
			collidedPackage = other.gameObject;
		}
	}
	//Check if you no longer fly over a package
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Package"))
		{
			PickUpPackage.SetActive(false);
			collidedPackage = null;
		}
	}	
}
