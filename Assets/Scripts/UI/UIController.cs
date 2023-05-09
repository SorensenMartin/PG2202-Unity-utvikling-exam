using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameManager gameManager;
	
	public GameObject optionsMenu;
	public GameObject mainMenu;
	
	public Button startButton;
	public Button restartButton;
	
	public SaveAndLoadHighScores highScoreLoader;
	
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

	public void goToOptions()
	{
		mainMenu.SetActive(false);
		optionsMenu.SetActive(true);
		highScoreLoader.LoadHighScores();
	}

	public void goToMainMenu()
	{
		mainMenu.SetActive(true);
		optionsMenu.SetActive(false);
	}

}

