using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Button startButton;
	public Button restartButton;
	public GameManager gameManager;

	void Start()
	{
		Debug.Log("Start UIController");		
	}
	
	public void Update()
	{
		
		if (gameManager.currentState == GameManager.GameState.Start)
		{
			startButton.gameObject.SetActive(true);			
			if (startButton.onClick.GetPersistentEventCount() == 0)
			{
				startButton.onClick.AddListener(gameManager.StartGame);
			}
		}
		if (gameManager.currentState == GameManager.GameState.Playing)
		{
			startButton.gameObject.SetActive(false);
			restartButton.gameObject.SetActive(false);
		}
		if (gameManager.currentState == GameManager.GameState.GameOver)
		{
			restartButton.gameObject.SetActive(true);
			if (restartButton.onClick.GetPersistentEventCount() == 0)
			{
				restartButton.onClick.AddListener(gameManager.ResetGame);
			}
		}

	}

}
