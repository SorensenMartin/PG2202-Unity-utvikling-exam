using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Workshop : MonoBehaviour
{
	public GameObject workshopUI;
	public GameObject GameUI;
	public GameObject SpaceShip;
	public GameObject shipButtons;
	public Player player;			
	
	public TextMeshProUGUI GarageTxt;
	public TextMeshProUGUI RespondTxt;


	private void OnTriggerEnter(Collider other)
	{
		SpaceShip = GameObject.Find("Desert Rider");
		player = SpaceShip.GetComponent<Player>();

		if (other.gameObject == SpaceShip)
		{
			GameUI.SetActive(false);
			SpaceShip.SetActive(false);
			workshopUI.SetActive(true);
			RespondTxt.text = "What do you want to do?";
			if (player.mechanicalEngine == true)
			{
				GarageTxt.text = "As you arrive back at the workshop with the engine in tow, the robot mechanic eagerly greets you." +
					" 'Ah, you've returned!' he exclaims. 'And with the engine we needed, no less." +
					" Excellent work, traveler. Now we can finally get to work on upgrading your ship.'" +
					"The robot mechanic takes the engine from you and sets to work, quickly getting to task on integrating" +
					"it into your ship's systems. As he works, he explains to you the different upgrades he can offer," +
					" including improved weapons, stronger shields, and more efficient engines. " +
					"'These upgrades don't come cheap, mind you,' he warns. 'But with the engine you've brought us," +
					" we can offer you a fair price for our services. And believe me, it will be worth every penny." +
					" Your ship will be faster, stronger, and more capable than ever before.'";
				workshopUI.SetActive(true);
				shipButtons.SetActive(true);
			}

		}
	}		
}
