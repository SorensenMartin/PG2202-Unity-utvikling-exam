using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartQuest : MonoBehaviour
{
	public GameObject QuestUI;
	public GameObject GameUI;
	public GameObject SpaceShip;
	public GameObject QuestPackage;
	public GameObject WorldPackages;
	public GameObject QuestIcon;
	public Player player;

	public Button acceptQuestButton;
	public Button returnQuestButton;
	public Button deliverScrapButton;
	
	public bool questAccept = false;
	public bool deliveredQuest = false;

	public TextMeshProUGUI QuestTxt;
	public TextMeshProUGUI RespondTxt;


	private void OnTriggerEnter(Collider other)
	{
		SpaceShip = GameObject.Find("Desert Rider");
		player = SpaceShip.GetComponent<Player>();

		if (other.gameObject == SpaceShip) 
		{
			GameUI.SetActive(false);
			SpaceShip.SetActive(false);
			Cursor.visible = true;
			RespondTxt.text = "What do you want to do?";
			if (questAccept == false && deliveredQuest == false)
			{
				Debug.Log("Spaceship has triggered the box trigger for the first time!");
				QuestUI.SetActive(true);
				GameUI.SetActive(false);
				acceptQuestButton.gameObject.SetActive(true);
			}
			else if (questAccept == true)
			{
				Debug.Log("Spaceship has triggered the box trigger for the second time!");
				QuestTxt.text = "As the traveler enters the city, a holographic image of the city's leader appears " +
					"before them. The leader speaks in a cautious tone, \"Welcome back, traveler. Did you manage" +
					" to retrieve the package as we requested?\" The leader's eyes flicker" +
					" with a mix of hope and apprehension.";
				QuestUI.SetActive(true);
				acceptQuestButton.gameObject.SetActive(false);
				returnQuestButton.gameObject.SetActive(true);
			}
			else if (deliveredQuest == true)
			{
				Debug.Log("Spaceship has triggered the box trigger for the third time!");
				QuestUI.SetActive(true);
				returnQuestButton.gameObject.SetActive(false);
				deliverScrapButton.gameObject.SetActive(true);
			}
				
		}
	}
	public void AcceptQuest()
	{
		Debug.Log("Quest has been accepted!");
		RespondTxt.text = "Mission Accepted";
		questAccept = true;
		acceptQuestButton.gameObject.SetActive(false);
		QuestPackage.SetActive(true);
		QuestIcon.SetActive(true);
	}

	public void ReturnQuest()
	{
		if (player.packages == 1)
		{
			QuestTxt.text = "Thank you for delivering the package for us. We couldn't have done it without you." +
				" As a token of our gratitude, we would like to offer you 1000 gold." +
				" You can always come back here to deliver scrap and packages for a small coin purse." +
				" We're always in need of resources to sustain our city. There should be alot of lost packages" +
				" scatterd around, and you seem to be resourcefull enough to locate a few. " +
				"If your looking for some upgrades, see if you can find Scorched Skies " +
				"Shipwork in one of the lonley mountains north of here, there is usually a" +
				" ship or two flying above it looking for some repairs!" +
				" Safe travels, adventurer.";
			Debug.Log("Quest has been returned!");
			RespondTxt.text = "Mission Completed";
			player.money += 1000;
			deliveredQuest = true;
			questAccept = false;
			returnQuestButton.gameObject.SetActive(false);
			WorldPackages.SetActive(true);
			player.packages -= 1;
		}
		else
		{
			RespondTxt.text = "I dont have the package yet";
		}

	}

	public void DeliverScrap()
	{
		if (player.packages >= 1)
		{
			Debug.Log("Scrap has been delivered!");
			RespondTxt.text = "Package has been sold";
			player.packages -= 1;
			player.money += 450;
		}
		else if (player.packages == 0)
		{
			Debug.Log("No scrap to deliver!");
			RespondTxt.text = "No packages to deliver";
		}
	}

}
