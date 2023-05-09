using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ProgressBar : MonoBehaviour
{

	public int currentHealth;
	public int maximumHealth; 
	public int currentFuel;
	public int maximumFuel;
	public int money;
	public Image fillHealth;
	public Image fillFuel;
	public Player SpaceShip;
	public TextMeshProUGUI HealthTxt;
	public TextMeshProUGUI FuelTxt;
	public TextMeshProUGUI MoneyTxt;

	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("ProgressBar");
	}

    // Update is called once per frame
    void Update()
    {
		//does not do anything if the ship is turned off
		if (SpaceShip == null)
		{
			return;
		}
		else
		{
			//updates the health, fuel, and money on the inGameOverlayUI
			money = SpaceShip.money;
			MoneyTxt.text = "$: " + money;

			currentHealth = SpaceShip.health;
			maximumHealth = SpaceShip.maxHealth;
			GetCurrentHealthFill();
			HealthTxt.text = "HP: " + currentHealth + "/" + maximumHealth;

			currentFuel = SpaceShip.fuel;
			GetCurrentFuelFill();
			FuelTxt.text = "Fuel: " + currentFuel + "/" + maximumFuel;
		}
	}

	//Gets the amount of fuel left
	void GetCurrentFuelFill()
	{
		float fillAmountFuel = (float)currentFuel / (float)maximumFuel;
		fillFuel.fillAmount = fillAmountFuel;
	}
	
	//Gets the amount of health currently
	void GetCurrentHealthFill()
    {
        float fillAmountHealth = (float)currentHealth / (float)maximumHealth;
		fillHealth.fillAmount = fillAmountHealth;
	}
}
