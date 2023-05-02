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
	public GameObject startScreen;
	public Button startButton;

	void Start()
	{
		currentState = GameState.Start;
		startScreen.SetActive(true);
		startButton.onClick.AddListener(StartGame);
	}

	void Update()
	{
		switch (currentState)
		{
			case GameState.Start:
				// Do nothing
				break;
			case GameState.Playing:
				// Update game logic
				break;
			case GameState.GameOver:
				// Show game over screen
				break;
		}
	}

	void StartGame()
	{
		currentState = GameState.Playing;
		startScreen.SetActive(false);
		// Start the game
	}

	void EndGame()
	{
		currentState = GameState.GameOver;
		// End the game
	}
}
