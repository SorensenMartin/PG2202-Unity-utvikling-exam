using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour
{
	public GameObject QuestUI;
	public Button acceptQuestButton;
	public Button returnQuestButton;
	public Button deliverScrapButton;
	public GameObject GameUI;
	public GameObject SpaceShip;
	
	
	public bool questAccept = false;
	public bool deliveredQuest = false;
	

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
				acceptQuestButton.gameObject.SetActive(false);
				returnQuestButton.gameObject.SetActive(true);
			}
			else if (deliveredQuest == true)
			{
				Debug.Log("Spaceship has triggered the box trigger for the third time!");
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

}
