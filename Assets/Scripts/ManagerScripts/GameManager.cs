using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//The different states the GameManager is responsible for
	public enum GameState
	{
		Start,
		Playing,
		Quest,
		GameOver
	}
	//Objects controlled
	public GameState currentState;
	public GameObject StartScreen;
	public GameObject EndScreen;
	public GameObject UIOverlay;
	public GameObject Spaceship;
	public GameObject Turrets;
	public GameObject Quests;
	public SoundManager soundManager;


	void Start()
	{
		Debug.Log("Start GameManager");
		currentState = GameState.Start;
		StartScreen.SetActive(true);
		Spaceship.SetActive(false);
		EndScreen.SetActive(false);
		UIOverlay.SetActive(false);
		Turrets.SetActive(false);
	}

	void Update()
	{
		switch (currentState)
		{
			case GameState.Start:				
				
				break;
			case GameState.Playing:
				if (Input.GetKeyDown(KeyCode.Escape) && UIOverlay.activeSelf == true)				
				{
					Start();
					Cursor.visible = true;
				}			
				break;
			case GameState.Quest:
				Spaceship.SetActive(false);
				break;
			case GameState.GameOver:
				Spaceship.SetActive(false);
				EndScreen.SetActive(true);
				UIOverlay.SetActive(false);
				break;
		}
	}
	
	public void StartGame()
	{
		//Activates the spaceship and disables the startscreen
		Debug.Log("Now Playing");
		currentState = GameState.Playing;
		StartScreen.SetActive(false);
		Spaceship.SetActive(true);
		Turrets.SetActive(true);
		UIOverlay.SetActive(true);
		Quests.SetActive(true);
		Cursor.visible = false;
	}	

	public void EndGame()
	{
		//Activates the endscreen and disables the spaceship
		currentState = GameState.GameOver;
		Cursor.visible = true;
		Turrets.SetActive(false);
	}
	
	public void QuitGame()
	{
		//Quits the application
		Application.Quit();
		Debug.Log("Application has been quit");
	}

	public void ResetGame()
	{
		//Resets the scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Quest()
	{
		currentState = GameState.Quest;
		Spaceship.SetActive(false);
		Quests.SetActive(true);
		UIOverlay.SetActive(true);
		Cursor.visible = true;
	}
}
