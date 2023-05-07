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
	public Player player;
	public GameObject AircraftController;

	public Button buyFuelButton;
	public Button buyHealthButton;
	public Button leaveCityButton;

	public TextMeshProUGUI RespondTxt;

	private void Start()
	{
		Debug.Log("Started CityUI.cs");
		AircraftController = GameObject.Find("Aircraft controller");
		SpaceShip = GameObject.Find("Desert Rider");
		player = SpaceShip.GetComponent<Player>();
	}

	public void buyFuel()
	{
		Debug.Log("Fuel has been bought!");
		player.fuel = 1500;
	}

	public void buyHealth()
	{
		Debug.Log("Health has been bought!");
		if (player.health < 10) 
		{ 
			player.health += 1;
		}
		
	}

	public void leaveCity()
	{
		Debug.Log("City has been left!");
		GameUI.SetActive(true);
		SpaceShip.SetActive(true);
		QuestUI.SetActive(false);

		Vector3 newPosition = AircraftController.transform.position + Vector3.back * 20f;
		AircraftController.transform.position = newPosition;
	}
}
