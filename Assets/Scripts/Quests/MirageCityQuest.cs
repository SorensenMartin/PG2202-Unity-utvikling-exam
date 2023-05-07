using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MirageCityQuest : MonoBehaviour
{
	public GameObject mirageCityUI;
	public GameObject GameUI;
	public GameObject SpaceShip;	
	public Player player;
	public GameObject EngineButton;

	public TextMeshProUGUI MirageTxtRespond;
	public TextMeshProUGUI MirageCityTxt;
	

	
	private void OnTriggerEnter(Collider other)
	{
		SpaceShip = GameObject.Find("Desert Rider");
		player = SpaceShip.GetComponent<Player>();

		if (other.gameObject == SpaceShip)
		{
			Debug.Log("Entered Mirage City");
			mirageCityUI.SetActive(true);
			GameUI.SetActive(false);
			SpaceShip.SetActive(false);

			if (player.mechanicalEngine == false)
			{
				EngineButton.SetActive(true);
			}
			if (player.mechanicalEngine == true)
			{
				MirageCityTxt.text = "As you enter the gates of Mirage City, you're greeted by the familiar sights and sounds of" +
				" the bustling enclave. The local merchants shout out their wares as you make your way through the crowds." +
				" The once-prominent engine shop catches your eye, but upon closer inspection, you notice it's now closed." +
				" It seems the residents have moved on to other ventures. Despite the change, the city still holds a charm" +
				" that draws you in.";
			}			
		}
	}
	public void BuyEngine()
	{
		if (player.money >= 300)
		{
			player.mechanicalEngine = true;
			player.money -= 300;
			EngineButton.SetActive(false);
			MirageTxtRespond.text = "Engine has been bought!";			
		}
		else
		{
			MirageTxtRespond.text = "Not enough money";
		}
	}
}
