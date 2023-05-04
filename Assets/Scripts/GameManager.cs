using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum GameState
	{
		Start,
		Playing,
		GameOver
	}

	public GameState currentState;
	public GameObject StartScreen;
	public GameObject EndScreen;
	public GameObject UIOverlay;
	public GameObject Spaceship;
	public GameObject Turrets;	
	public Camera StartCamera;


	void Start()
	{
		Debug.Log("Start GameManager");
		currentState = GameState.Start;
		StartScreen.SetActive(true);
		Spaceship.SetActive(false);
		EndScreen.SetActive(false);
	}

	void Update()
	{
		switch (currentState)
		{
			case GameState.Start:				
				
				break;
			case GameState.Playing:
				StartScreen.SetActive(false);
				Spaceship.SetActive(true);
				StartCamera.enabled = false;

				break;
			case GameState.GameOver:
				Spaceship.SetActive(false);
				EndScreen.SetActive(true);
				Turrets.SetActive(false);
				UIOverlay.SetActive(false);
				break;
		}
	}

	public void StartGame()
	{
		Debug.Log("Now Playing");
		currentState = GameState.Playing;
		StartScreen.SetActive(false);
		Spaceship.SetActive(true);
		Turrets.SetActive(true);
		UIOverlay.SetActive(true);
	}	

	public void EndGame()
	{
		currentState = GameState.GameOver;		
	}

	public void ResetGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
