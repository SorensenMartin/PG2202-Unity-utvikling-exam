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
	
	public Button acceptQuestButton;
	public Button returnQuestButton;
	public Button deliverScrapButton;
	
	public bool questAccept = false;
	public bool deliveredQuest = false;

	public TextMeshProUGUI QuestTxt;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == SpaceShip) 
		{
			GameUI.SetActive(false);
			SpaceShip.SetActive(false);

			if (questAccept == false)
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
		questAccept = true;
		acceptQuestButton.gameObject.SetActive(false);
	}

	public void ReturnQuest()
	{
		Debug.Log("Quest has been returned!");
		deliveredQuest = true;
		returnQuestButton.gameObject.SetActive(false);
		
	}

	public void DeliverScrap()
	{
		Debug.Log("Scrap has been delivered!");		
	}

}
