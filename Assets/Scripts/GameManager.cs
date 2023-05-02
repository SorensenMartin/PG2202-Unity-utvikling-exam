using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public GameObject Spaceship;	

	void Start()
	{
		Debug.Log("Start GameManager");
		currentState = GameState.Start;
		StartScreen.SetActive(true);
		
	}

	void Update()
	{
		switch (currentState)
		{
			case GameState.Start:
				// Do nothing
				break;
			case GameState.Playing:
				Debug.Log("Now Playing");
				StartScreen.SetActive(false);
				Spaceship.SetActive(true);

				break;
			case GameState.GameOver:
				// Show game over screen
				break;
		}
	}

	public void StartGame()
	{
		currentState = GameState.Playing;
		StartScreen.SetActive(false);
		Spaceship.SetActive(true);
		
	}

	void EndGame()
	{
		currentState = GameState.GameOver;
		Spaceship.SetActive(false);
		StartScreen.SetActive(true);
	}
}
