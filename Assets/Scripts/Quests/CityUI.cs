using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityUI : MonoBehaviour
{
	public GameObject GameUI;
	public GameObject SpaceShip;
	public GameObject QuestUI;
	public GameObject WorkShopUI;
	public GameObject MirageCityUI;
	public GameObject BoostButton;
	public GameObject UpgradeButton;
	public GameObject AircraftController;
	
	public Player player;
	public SpaceshipController spaceshipController;
	
	public TextMeshProUGUI RespondTxt;
	public TextMeshProUGUI workshopRespondTxt;

	private void Start()
	{
		Debug.Log("Started CityUI.cs");
		AircraftController = GameObject.Find("Aircraft controller");
		SpaceShip = GameObject.Find("Desert Rider");
		player = SpaceShip.GetComponent<Player>();
		spaceshipController = AircraftController.GetComponent<SpaceshipController>();
	}

	public void buyFuel()
	{
		if (player.money >= 200)
		{
			Debug.Log("Fuel has been bought!");
			player.fuel = 1500;
			player.money -= 200;
			RespondTxt.text = "Fuel has been bought!";
			workshopRespondTxt.text = "Fuel has been bought!";
		}
		else
		{
			RespondTxt.text = "Not enough money";
			workshopRespondTxt.text = "Not enough money";
		}
		
	}

	public void buyHealth()
	{

		if (player.money >= 50)
		{			
			if (player.health < 10)
			{
				player.health += 1;
				player.money -= 50;
				Debug.Log("Health has been bought!");
				RespondTxt.text = "Health has been bought!";
				workshopRespondTxt.text = "Health has been bought!";
			}
		}
		else
		{
			RespondTxt.text = "Not enough money";
			workshopRespondTxt.text = "Not enough money";
		}	
	}

	public void leaveCity()
	{
		Debug.Log("City has been left!");
		GameUI.SetActive(true);
		SpaceShip.SetActive(true);
		QuestUI.SetActive(false);
		WorkShopUI.SetActive(false);
		MirageCityUI.SetActive(false);
		Cursor.visible = false;

		Vector3 newPosition = AircraftController.transform.position + Vector3.back * 10f;
		AircraftController.transform.position = newPosition;
	}

	public void upgradeSpeed()
	{
		if (player.money >= 1000)
		{
			spaceshipController.speed += 10;
			spaceshipController.originalSpeed = spaceshipController.speed;
			player.money -= 1000;
			workshopRespondTxt.text = "Speed has been upgraded!";
			
		}
		else
		{
			workshopRespondTxt.text = "Not enough money";
		}
	}

	public void upgradeHealth()
	{
		if (player.money >= 200)
		{
			player.maxHealth += 1;
			player.money -= 200;
			workshopRespondTxt.text = "Health has been upgraded!";
		}
		else
		{
			workshopRespondTxt.text = "Not enough money";
		}
	}

	public void SpeedBoost()
	{
		if (player.money >= 500)
		{
			player.boostUpgrade = true;
			player.money -= 500;
			BoostButton.SetActive(true);
			UpgradeButton.SetActive(false);
			workshopRespondTxt.text = "Boost activated!";
		}
		else
		{
			workshopRespondTxt.text = "Not enough money";
		}
	}
}
